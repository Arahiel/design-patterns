using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Command
{
    public interface ICommand
    {
        void Call();
        void Undo();
        bool Success { get; set; }
    }

    public class Command : ICommand
    {
        private readonly Account _account;

        public enum Action
        {
            Deposit,
            Withdraw
        }

        public Action TheAction;
        public int Amount;
        public bool Success { get; set; }

        public Command(Account account, Action theAction, int amount)
        {
            TheAction = theAction;
            Amount = amount;
            _account = account;
        }

        public void Call()
        {
            switch (TheAction)
            {
                case Action.Deposit:
                    _account.Deposit(Amount);
                    Success = true;
                    break;
                case Action.Withdraw:
                    Success = _account.Withdraw(Amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Undo()
        {
            switch (TheAction)
            {
                case Action.Deposit:
                    if (Success)
                    {
                        _account.Withdraw(Amount);
                    }
                    break;
                case Action.Withdraw:
                    _account.Deposit(Amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public class Account
    {
        public int Balance { get; set; }

        internal void Deposit(int amount)
        {
            Balance += amount;
            WriteLine($"Deposited {amount}");
        }

        internal bool Withdraw(int amount)
        {
            var result = amount <= Balance;
            if (result)
            {
                Balance -= amount;
                WriteLine($"Withdrew {amount}");
            }

            return result;
        }

        public override string ToString()
        {
            return $"{nameof(Balance)}: {Balance}";
        }
    }

    public class CompositeCommand : List<Command>, ICommand
    {
        public CompositeCommand()
        {
        }

        public CompositeCommand(IEnumerable<Command> collection) : base(collection)
        {
        }

        public virtual void Call()
        {
            ForEach(c => c.Call());
        }

        public virtual void Undo()
        {
            foreach (var command in Enumerable.Reverse(this))
            {
                command.Undo();
            }
        }

        public virtual bool Success
        {
            get => this.All(c => c.Success);
            set => ForEach(c => c.Success = value);
        }
    }

    public class MoneyTransferCommand : CompositeCommand
    {
        public MoneyTransferCommand(Account from, Account to, int amount)
        {
            AddRange(new []
            {
                new Command(from, Command.Action.Withdraw, amount),
                new Command(to, Command.Action.Deposit, amount)
            });
        }

        public override void Call()
        {
            Command last = null;
            foreach (var command in this)
            {
                if (last == null || last.Success)
                {
                    command.Call();
                    last = command;
                }
                else
                {
                    command.Undo();
                    break;
                }
            }
        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            var acc = new Account();
            var acc2 = new Account();

            var deposit = new Command(acc, Command.Action.Deposit, 100);
            deposit.Call();

            WriteLine($"Account 1: {acc}");
            WriteLine($"Account 2: {acc2}");
            var transferCommands = new MoneyTransferCommand(acc, acc2, 100);
            transferCommands.Call();

            WriteLine($"Account 1: {acc}");
            WriteLine($"Account 2: {acc2}");

            transferCommands.Undo();

            WriteLine($"Account 1: {acc}");
            WriteLine($"Account 2: {acc2}");

            ReadKey();
        }
    }
}

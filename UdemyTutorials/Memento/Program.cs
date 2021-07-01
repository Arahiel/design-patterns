using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            var tm = new TokenMachine();
            var t = new Token(111);
            var m1 = tm.AddToken(t);
            PrintTokens(tm);
            t.Value = 333;
            var m2 = tm.AddToken(t);
            PrintTokens(tm);
            tm.Revert(m1);
            PrintTokens(tm);

            ReadKey();
        }

        private static void PrintTokens(TokenMachine tm)
        {
            WriteLine(string.Join(", ", tm.Tokens.Select(x => x.Value)));
        }
    }
}

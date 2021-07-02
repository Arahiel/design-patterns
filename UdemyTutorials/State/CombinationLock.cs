using System;
using static System.Console;

namespace State
{
    public class CombinationLock
    {
        public string Status { get; private set; }

        private readonly int[] combination;

        private enum LockStatus
        {
            LOCKED,
            ERROR,
            OPEN,
            CONTINUE
        }

        public CombinationLock(int[] combination)
        {
            this.combination = combination;
            Status = LockStatus.LOCKED.ToString();
        }

        public void ResetLock()
        {
            var status = LockStatus.LOCKED;
            SetCursorPosition(0, 0);
            UpdateStatus(status, 0);
        }

        public void EnterDigit(int digit)
        {
            if (digit.ToString().Length > 1)
            {
                throw new ArgumentException("Argument has too many digits. Only one allowed at time.");
            }

            var lockStatus = CheckCode(digit);
            UpdateStatus(lockStatus, digit);
        }

        private void UpdateStatus(LockStatus lockStatus, int digit)
        {
            if (lockStatus == LockStatus.CONTINUE)
            {
                Status += digit.ToString();
            }
            else
            {
                Clear();
                Status = lockStatus.ToString();
                Write(Status);
            }
        }

        private LockStatus CheckCode(int digit)
        {
            if (Status.Equals(LockStatus.ERROR.ToString()))
            {
                return LockStatus.ERROR;
            }

            if (Status.Equals(LockStatus.OPEN.ToString()))
            {
                return LockStatus.OPEN;
            }

            if (Status.Equals(LockStatus.LOCKED.ToString()))
            {
                Status = string.Empty;
            }

            if (digit != combination[Status.Length])
            {
                return LockStatus.ERROR;
            }
            else
            {
                if (combination.Length - 1 == Status.Length)
                {
                    return LockStatus.OPEN;
                }
                else
                {
                    return LockStatus.CONTINUE;
                }
            }
        }
    }
}

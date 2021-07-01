using System;

namespace Observer
{
    public class RatEventArgs : EventArgs
    {
        public Rat Recipient;

        public RatEventArgs(Rat recipient)
        {
            Recipient = recipient;
        }
    }
}

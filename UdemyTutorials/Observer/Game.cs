using System;

namespace Observer
{
    public class Game
    {
        // todo
        // remember - no fields or properties! - only events and methods
        public event EventHandler<EventArgs> RatJoined;
        public event EventHandler<EventArgs> RatDied;
        public event EventHandler<RatEventArgs> RatUpdate;

        public void Join(Rat senderRat)
        {
            RatJoined?.Invoke(senderRat, EventArgs.Empty);
            Console.WriteLine("Rat joined the game!");
        }

        public void Die(Rat rat)
        {
            RatDied?.Invoke(rat, EventArgs.Empty);
            Console.WriteLine("Rat died!");
        }

        public void UpdateRat(Rat senderRat, Rat recipientRat)
        {
            RatUpdate?.Invoke(senderRat, new RatEventArgs(recipientRat));
        }
    }
}

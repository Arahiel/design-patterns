using System;
using System.Collections.Generic;

namespace Observer
{
    public class Rat : IDisposable
    {
        public int Attack = 1;
        private readonly Game game;
        private List<Rat> otherRats = new List<Rat>();

        public Rat(Game game)
        {
            this.game = game;
            game.RatJoined += OnRatJoined;
            game.RatDied += OnRatDied;
            game.RatUpdate += OnRatUpdate;

            game.Join(this);
        }

        private void OnRatJoined(object sender, EventArgs e)
        {
            if (sender != this)
            {
                var senderRat = (Rat)sender;
                otherRats.Add(senderRat);
                UpdateAttack();
                game.UpdateRat(this, senderRat);
            }
        }

        private void OnRatDied(object sender, EventArgs e)
        {
            if (sender != this)
            {
                otherRats.Remove((Rat)sender);
                UpdateAttack();
            }
        }

        private void OnRatUpdate(object sender, RatEventArgs e)
        {
            if (e.Recipient == this)
            {
                var senderRat = (Rat)sender;
                if (!otherRats.Contains(senderRat))
                {
                    otherRats.Add(senderRat);
                    UpdateAttack();
                }
            }
        }

        private void UpdateAttack()
        {
            Attack = otherRats.Count + 1;
        }

        public void Dispose()
        {
            game.RatJoined -= OnRatJoined;
            game.RatDied -= OnRatDied;
            game.Die(this);
        }
    }
}

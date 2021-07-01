using System;

namespace ChainOfResponsibility
{
    public class Goblin : Creature, IDisposable
    {
        protected Game Game;

        public Goblin(Game game)
        {
            BaseDefense = 1;
            BaseAttack = 1;
            Game = game;
            Game.Queries += Handle;
        }

        protected virtual void Handle(object sender, Query q)
        {
            if (q.WhatToQuery == Query.Argument.Defense
                && q.CreatureType == typeof(Goblin))
            {
                q.Value++;
            }
        }

        public override int Attack
        {
            get
            {
                var q = new Query(GetType(), Query.Argument.Attack, BaseAttack);
                Game.PerformQuery(this, q);
                return q.Value;
            }
        }

        public override int Defense
        {
            get
            {
                var q = new Query(GetType(), Query.Argument.Defense, BaseDefense - 1);
                Game.PerformQuery(this, q);
                return q.Value;
            }
        }

        public void Dispose()
        {
            Game.Queries -= Handle;
        }
    }
}
namespace ChainOfResponsibility
{
    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game)
        {
            BaseDefense = 3;
            BaseAttack = 3;
        }

        protected override void Handle(object sender, Query q)
        {
            switch (q.WhatToQuery)
            {
                case Query.Argument.Attack when q.CreatureType == typeof(Goblin):
                case Query.Argument.Defense when q.CreatureType == typeof(Goblin):
                    q.Value++;
                    break;
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
                var q = new Query(GetType(), Query.Argument.Defense, BaseDefense);
                Game.PerformQuery(this, q);
                return q.Value;
            }
        }
    }
}
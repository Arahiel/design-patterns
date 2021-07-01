using System;
using System.Collections.Generic;

namespace ChainOfResponsibility
{
    public class Game
    {
        public List<Creature> Creatures = new List<Creature>();
        public event EventHandler<Query> Queries;

        public void PerformQuery(object sender, Query q)
        {
            Queries?.Invoke(sender, q);
        }
    }
}
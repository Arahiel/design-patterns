using System;

namespace ChainOfResponsibility
{
    public class Query
    {
        public enum Argument
        {
            Attack,
            Defense
        }

        public Type CreatureType;
        public Argument WhatToQuery;
        public int Value;

        public Query(Type creatureType, Argument whatToQuery, int value)
        {
            CreatureType = creatureType;
            WhatToQuery = whatToQuery;
            Value = value;
        }
    }
}
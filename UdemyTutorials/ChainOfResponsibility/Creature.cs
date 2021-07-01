namespace ChainOfResponsibility
{
    public abstract class Creature
    {
        protected int BaseAttack;
        protected int BaseDefense;

        public abstract int Attack { get; }
        public abstract int Defense { get; }
    }
}
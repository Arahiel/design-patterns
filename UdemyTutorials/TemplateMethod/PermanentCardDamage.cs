namespace TemplateMethod
{

    public class PermanentCardDamage : CardGame
    {
        public PermanentCardDamage(Creature[] creatures) : base(creatures)
        {
        }

        protected override void Hit(Creature attacker, Creature other)
        {
            other.Health = attacker.Attack > other.Health ? 0 : other.Health - attacker.Attack;
        }
    }

}

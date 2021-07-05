namespace TemplateMethod
{

    public class TemporaryCardDamageGame : CardGame
    {
        public TemporaryCardDamageGame(Creature[] creatures) : base(creatures)
        {
        }

        protected override void Hit(Creature attacker, Creature other)
        {
            if (attacker.Attack >= other.Health)
            {
                other.Health = 0;
            }
        }
    }
}

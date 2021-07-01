namespace Mediator
{
    public class Participant
    {
        public int Value { get; set; }
        private Mediator Mediator { get; }
        public string Name { get; set; }

        public Participant(Mediator mediator)
        {
            Mediator = mediator;
            Mediator.Join(this);
        }

        public Participant(Mediator mediator, string name)
        {
            Mediator = mediator;
            Name = name;
            Mediator.Join(this);
        }

        public void Say(int n)
        {
            Mediator.Send(this, n);
        }
    }
}

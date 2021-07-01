namespace Decorator
{
    public class Dragon // no need for interfaces
    {
        private readonly Bird _bird = new Bird();
        private readonly Lizard _lizard = new Lizard();
        private int _age;

        public int Age
        {
            set
            {
                _bird.Age = value;
                _lizard.Age = value;
                _age = value;
            }

            get => _age;
        }

        public string Fly()
        {
            return _bird.Fly();
        }

        public string Crawl()
        {
            return _lizard.Crawl();
        }
    }
}
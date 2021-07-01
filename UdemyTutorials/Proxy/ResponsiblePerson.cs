namespace Proxy
{
    public class ResponsiblePerson : IPerson
    {
        private readonly Person _person;
        public ResponsiblePerson(Person person)
        {
            _person = person;
        }

        public int Age
        {
            get => _person.Age;
            set => _person.Age = value;
        }

        public string Drink()
        {
            if (Age < 18) return "too young";
            return _person.Drink();
        }

        public string Drive()
        {
            if (Age < 16) return "too young";
            return _person.Drive();
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }
    }
}
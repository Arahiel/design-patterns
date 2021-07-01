namespace Factory
{
    public class PersonFactory
    {
        private int _personCount = 0;
        public Person CreatePerson(string name)
        {
            return new Person(_personCount++, name);
        }
    }
}

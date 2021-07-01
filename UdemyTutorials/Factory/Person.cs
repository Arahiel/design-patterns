namespace Factory
{
    public class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        internal Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }
}
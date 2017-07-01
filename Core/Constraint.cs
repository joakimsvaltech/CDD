namespace CDD.Core
{
    public class Constraint
    {
        public Constraint(string name, string assert)
        {
            Name = name;
            Assert = assert;
        }

        public string Name { get; set; }
        public string Assert { get; set; }

        public override string ToString()
            => $"{Name}: {Assert}";
    }
}

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

        public static Constraint Parse(string constraint)
        {
            var parts = constraint.Split(new[] { ':' }, 2);
            return new Constraint(parts[0], parts[1].Trim());
        }

        public override string ToString()
            => $"{Name}: {Assert}";
    }
}

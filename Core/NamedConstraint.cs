using CDD.Core.Constraints;

namespace CDD.Core
{
    public class NamedConstraint
    {
        public NamedConstraint(Constraint constraint, string name = "Constraint")
        {
            Constraint = constraint;
            Name = name;
        }

        public string Name { get; set; }
        public Constraint Constraint { get; set; }

        public static NamedConstraint Parse(string constraint)
        {
            var parts = constraint.Split(new[] { ':' }, 2);
            return new NamedConstraint(Constraint.Parse(parts[0]), parts[1].Trim());
        }

        public override string ToString()
            => $"{Name}: {Constraint}";
    }
}

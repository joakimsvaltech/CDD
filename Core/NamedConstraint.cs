using CDD.Core.Perpetual;

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

        public override string ToString()
            => $"{Name}: {Constraint}";
    }
}

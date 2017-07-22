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
            var name = parts[0].Trim();
            var representation = parts[1].Trim();
            return new NamedConstraint(Translator.Translate(representation), name);
        }

        public override string ToString()
            => $"{Name}: {Constraint}";
    }
}

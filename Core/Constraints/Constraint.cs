namespace CDD.Core.Constraints
{
    public class Constraint
    {
        private string Representation { get; set; }

        public static Constraint Parse(string assert)
            => new Constraint {Representation = assert};

        public override string ToString()
            => Representation;
    }
}
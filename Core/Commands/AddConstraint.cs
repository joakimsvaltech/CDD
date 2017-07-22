namespace CDD.Core.Commands
{
    public class AddConstraint : InterpreterCommand
    {
        public string Name { get; set; }
        public string Constraint { get; set; }
        public override void Execute(Program program)
            => program.Add(Parser.CreateConstraint(Name, Constraint));
    }
}
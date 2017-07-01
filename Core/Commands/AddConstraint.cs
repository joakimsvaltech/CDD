namespace CDD.Core.Commands
{
    public class AddConstraint : InterpreterCommand
    {
        public string Name { get; set; }
        public string Constraint { get; set; }
        public override void Execute(Interpreter interpreter)
            => interpreter.Add(new Constraint(Name, Constraint));
    }
}
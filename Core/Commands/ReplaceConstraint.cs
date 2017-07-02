namespace CDD.Core.Commands
{
    public class ReplaceConstraint : InterpreterCommand
    {
        public string Name { get; set; }
        public string NewConstraint { get; set; }
        public override void Execute(Interpreter interpreter)
        {
            var constraint = interpreter.Remove(Name);
            constraint.Assert = NewConstraint;
            interpreter.Add(constraint);
        }
    }
}
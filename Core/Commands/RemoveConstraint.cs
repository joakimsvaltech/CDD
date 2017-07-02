namespace CDD.Core.Commands
{
    public class RemoveConstraint : InterpreterCommand
    {
        public string Name { get; set; }
        public override void Execute(Interpreter interpreter)
            => interpreter.Remove(Name);
    }
}
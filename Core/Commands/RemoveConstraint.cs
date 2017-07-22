namespace CDD.Core.Commands
{
    public class RemoveConstraint : InterpreterCommand
    {
        public string Name { get; set; }
        public override void Execute(Program program)
            => program.Remove(Name);
    }
}
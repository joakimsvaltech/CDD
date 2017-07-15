namespace CDD.Core.Commands
{
    public class RenameConstraint : InterpreterCommand
    {
        public string OldName { get; set; }
        public string NewName { get; set; }
        public override void Execute(Program interpreter)
        {
            var constraint = interpreter.Remove(OldName);
            constraint.Name = NewName;
            interpreter.Add(constraint);
        }
    }
}
namespace CDD.Core.Commands
{
    public class RenameConstraint : InterpreterCommand
    {
        public string OldName { get; set; }
        public string NewName { get; set; }
        public override void Execute(Program program)
        {
            var constraint = program.Remove(OldName);
            constraint.Name = NewName;
            program.Add(constraint);
        }
    }
}
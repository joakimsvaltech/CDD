namespace CDD.Core.Commands
{
    public class RenameConstraint : InterpreterCommand
    {
        public string OldName { get; set; }
        public string NewName { get; set; }
        public override void Execute(Interpreter interpreter)
        {
            throw new System.NotImplementedException();
        }
    }
}
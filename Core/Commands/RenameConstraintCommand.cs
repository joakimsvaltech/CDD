namespace CDD.Core.Commands
{
    public class RenameConstraintCommand : Command
    {
        public string OldName { get; set; }
        public string NewName { get; set; }
    }
}
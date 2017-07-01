namespace CDD.Core.Commands
{
    public class ReplaceConstraintCommand : Command
    {
        public string Name { get; set; }
        public string NewConstraint { get; set; }
    }
}
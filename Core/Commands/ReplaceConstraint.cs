namespace CDD.Core.Commands
{
    public class ReplaceConstraint : InterpreterCommand
    {
        public string Name { get; set; }
        public string NewConstraint { get; set; }
        public override void Execute(Interpreter interpreter)
        {
            throw new System.NotImplementedException();
        }
    }
}
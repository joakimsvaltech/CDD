namespace CDD.Core.Commands
{
    public class ReplaceConstraint : InterpreterCommand
    {
        public string Name { get; set; }
        public string NewConstraint { get; set; }
        public override void Execute(Program program)
        {
            program.Remove(Name);
            program.Add(Parser.CreateConstraint(Name, NewConstraint));
        }
    }
}
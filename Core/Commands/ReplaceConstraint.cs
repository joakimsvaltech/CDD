using CDD.Core.Constraints;

namespace CDD.Core.Commands
{
    public class ReplaceConstraint : InterpreterCommand
    {
        public string Name { get; set; }
        public string NewConstraint { get; set; }
        public override void Execute(Program interpreter)
        {
            var namedConstraint = interpreter.Remove(Name);
            namedConstraint.Constraint = Constraint.Parse(NewConstraint);
            interpreter.Add(namedConstraint);
        }
    }
}
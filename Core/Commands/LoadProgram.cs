using System.Linq;

namespace CDD.Core.Commands
{
    public class LoadProgram : InterpreterCommand
    {
        public string Name { get; set; }
        public override void Execute(Program program)
            => program.Constraints = Storage.Load(Name).Select(NamedConstraint.Parse);
    }
}
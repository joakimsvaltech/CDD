using System.Linq;

namespace CDD.Core.Commands
{
    public class LoadProgram : InterpreterCommand
    {
        public string Name { get; set; }
        public override void Execute(Program interpreter)
            => interpreter.Constraints = Storage.Load(Name).Select(NamedConstraint.Parse);
    }
}
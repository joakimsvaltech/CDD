using System.IO;
using System.Linq;

namespace CDD.Core.Commands
{
    public class LoadProgram : InterpreterCommand
    {
        public string Name { get; set; }
        public override void Execute(Interpreter interpreter)
            => interpreter.Constraints = File.ReadAllLines(Name + ".prg")
                .Select(Constraint.Parse);
    }
}
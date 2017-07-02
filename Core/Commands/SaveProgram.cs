using System.IO;
using System.Linq;

namespace CDD.Core.Commands
{
    public class SaveProgram : InterpreterCommand
    {
        public string Name { get; set; }
        public override void Execute(Interpreter interpreter)
            => File.WriteAllLines(Name + ".prg", interpreter.Constraints.Select(c => c.ToString()));
    }
}
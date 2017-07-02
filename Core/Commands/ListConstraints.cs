using System.Linq;
using CDD.Utility;

namespace CDD.Core.Commands
{
    public class ListConstraints : InterpreterCommand
    {
        public string Pattern { get; set; }
        public override void Execute(Interpreter interpreter)
        {
            Interactor.Caption("Constraints by name: " + Pattern);
            interpreter.Constraints
                .Where(c => c.Name.Contains(Pattern))
                .ForEach(Interactor.Output);
        }
    }
}
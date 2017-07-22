using System.Linq;

namespace CDD.Core.Commands
{
    using Utility;

    public class ListConstraints : InterpreterCommand
    {
        public string Pattern { get; set; }
        public override void Execute(Program program)
        {
            Interactor.Caption("Constraints by name: " + Pattern);
            program.Constraints
                .Where(c => c.Name.Contains(Pattern))
                .ForEach(Interactor.Output);
        }
    }
}
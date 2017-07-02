using CDD.Utility;

namespace CDD.Core.Commands
{
    public class PrintProgram : InterpreterCommand
    {
        public override void Execute(Interpreter interpreter)
        {
            Interactor.Caption("Program expressions:");
            interpreter.Expressions.ForEach(Interactor.Output);
            Interactor.Caption("Program constraints:");
            interpreter.Constraints.ForEach(Interactor.Output);
        }
    }
}
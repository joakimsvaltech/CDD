namespace CDD.Core.Commands
{
    using Utility;

    public class PrintProgram : InterpreterCommand
    {
        public override void Execute(Interpreter interpreter)
        {
            Interactor.Caption("Program constraints:");
            interpreter.Constraints.ForEach(Interactor.Output);
            Interactor.Caption("Program expressions:");
            interpreter.Expressions.ForEach(Interactor.Output);
        }
    }
}
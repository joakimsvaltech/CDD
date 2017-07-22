namespace CDD.Core.Commands
{
    using Utility;

    public class PrintProgram : InterpreterCommand
    {
        public override void Execute(Program program)
        {
            Interactor.Caption("Program constraints:");
            program.Constraints.ForEach(Interactor.Output);
            Interactor.Caption("Program expressions:");
            program.Expressions.ForEach(Interactor.Output);
        }
    }
}
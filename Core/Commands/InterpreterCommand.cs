namespace CDD.Core.Commands
{
    public abstract class InterpreterCommand : Command
    {
        public abstract void Execute(Program program);
    }
}
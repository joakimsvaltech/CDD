namespace CDD.Core.Commands
{
    public class SaveProgram : InterpreterCommand
    {
        public string Name { get; set; }
        public override void Execute(Interpreter interpreter)
            => Storage.Save(Name, interpreter.Constraints);
    }
}
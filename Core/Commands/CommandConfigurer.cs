using System.Linq;
using System.Reflection;
using CDD.Utility;

namespace CDD.Core.Commands
{
    internal class CommandConfigurer
    {
        private readonly Command _command;
        private readonly Output _output;
        private readonly Input _input;

        public static void Configure(Command command, Output output, Input input)
            => new CommandConfigurer(command, output, input).Configure();

        private CommandConfigurer(Command command, Output output, Input input)
        {
            _command = command;
            _output = output;
            _input = input;
        }

        private void Configure()
        {
            var setters = _command.GetType()
                .GetProperties()
                .Where(p => p.CanWrite)
                .ToArray();
            if (!setters.Any())
                return;
            _output.Text(_command.CommandName);
            setters.ForEach(Configure);
        }

        private void Configure(PropertyInfo setter)
        {
            _output.Label(setter.Name);
            var value = _input.Text();
            setter.SetValue(_command, value);
        }
    }
}
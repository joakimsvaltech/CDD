using CDD.Utility;

namespace CDD.Core.Commands
{
    public abstract class Command
    {
        public string CommandName => GetType().Name.CamelCaseToWords();

        public void Configure(Output output, Input input)
            => CommandConfigurer.Configure(this, output, input);
    }
}
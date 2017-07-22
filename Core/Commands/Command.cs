using System.Linq;
using System.Reflection;

namespace CDD.Core.Commands
{
    using Utility;

    public abstract class Command
    {
        protected Interactor Interactor;
        protected Storage Storage;
        protected Parser Parser;

        private string CommandName => GetType().Name.CamelCaseToWords();

        public void Configure(Interactor interactor, Storage storage, Parser parser)
        {
            Interactor = interactor;
            Storage = storage;
            Parser = parser;
            var setters = GetType()
                .GetProperties()
                .Where(p => p.CanWrite)
                .ToArray();
            if (!setters.Any())
                return;
            interactor.Output(CommandName);
            setters.ForEach(Configure);
        }

        private void Configure(PropertyInfo setter)
        {
            Interactor.Label(setter.Name);
            var value = Interactor.Input();
            setter.SetValue(this, value);
        }
    }
}
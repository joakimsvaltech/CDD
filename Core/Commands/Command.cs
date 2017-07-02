using System.Linq;
using System.Reflection;

namespace CDD.Core.Commands
{
    using Utility;

    public abstract class Command
    {
        protected Interactor Interactor;
        protected Storage Storage;

        private string CommandName => GetType().Name.CamelCaseToWords();

        public void Configure(Interactor interactor, Storage storage)
        {
            Interactor = interactor;
            Storage = storage;
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
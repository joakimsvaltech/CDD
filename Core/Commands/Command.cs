using System.Linq;
using System.Reflection;
using CDD.Utility;

namespace CDD.Core.Commands
{
    public abstract class Command
    {
        protected Interactor Interactor;

        private string CommandName => GetType().Name.CamelCaseToWords();

        public void Configure(Interactor interactor)
        {
            Interactor = interactor;
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
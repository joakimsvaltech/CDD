using CDD.Core.Spec;

namespace CDD.Core
{
    public interface Parser
    {
        NamedConstraint ParseConstraint(string constraint);
        NamedConstraint CreateConstraint(string name, string representation);
    }

    public class ParserImpl : Parser
    {
        private readonly Translator _translator;

        public ParserImpl(Translator translator)
            => _translator = translator;

        public NamedConstraint ParseConstraint(string constraint)
        {
            var parts = constraint.Split(new[] { ':' }, 2);
            var name = parts[0].Trim();
            var representation = parts[1].Trim();
            return CreateConstraint(name, representation);
        }

        public NamedConstraint CreateConstraint(string name, string representation)
            => new NamedConstraint(_translator.Translate(representation), name);
    }
}
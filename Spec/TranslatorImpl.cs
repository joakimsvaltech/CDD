using System;
using CDD.Core.Spec;

namespace CDD.Perpetual
{
    public class TranslatorImpl : Translator
    {
        public Constraint Translate(string representation)
        {
            var tokens = Tokenizer.Parse(representation);
            var expression = Generator.Compile(tokens);
            switch (expression)
            {
                case Return returns:
                    return new OutputConstraint
                    {
                        Expression = returns.Statement,
                        Representation = representation
                    };
                default: throw new NotImplementedException();
            }
        }
    }
}
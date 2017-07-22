using System;

namespace CDD.Core
{
    using Constraints;
    using Expressions;

    public static class Translator
    {
        public static Constraint Translate(string representation)
        {
            var tokens = Tokenizer.Parse(representation);
            var expression = Expression.Translate(tokens);
            switch (expression)
            {
                case Return returnExpressions:
                    return new OutputConstraint
                    {
                        Expression = returnExpressions.Statement,
                        Representation = representation
                    };
                default: throw new NotImplementedException();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using CDD.Core.Expressions;
using CDD.Core.Tokens;

namespace CDD.Core.Constraints
{
    public class Constraint
    {
        private string Representation { get; set; }

        public static Constraint Parse(string representation)
        {
            var tokens = Tokenizer.Parse(representation);
            var expression = Expression.Translate(tokens);
            switch (expression)
            {
                case Return returnExpressions:
                    return new OutputConstraint(returnExpressions.Statement);
                default: throw new NotImplementedException();
            }
        }

        public override string ToString()
            => Representation;
    }
}
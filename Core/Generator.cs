using System.Collections.Generic;
using System.Linq;
using CDD.Core.Constraints;
using CDD.Core.Expressions;

namespace CDD.Core
{
    public class Generator
    {
        public static IEnumerable<Expression> Generate(params Constraint[] constraints)
        {
            if (constraints.Any())
                yield return GenerateExpression(constraints.Single()); 
        }

        private static Expression GenerateExpression(Constraint constraint)
        {
            switch (constraint)
            {
                case OutputConstraint oc: return oc.Expression;
                default: return null; 
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using CDD.Core.Spec;
using Expression = CDD.Core.Temporal.Expression;

namespace CDD.Core
{
    public interface Generator
    {
        IEnumerable<Expression> Generate(params Constraint[] constraints);
    }

    public class GeneratorImpl : Generator
    {
        public IEnumerable<Expression> Generate(params Constraint[] constraints)
        {
            if (constraints.Any())
                yield return GenerateExpression(constraints.Single());
        }

        private static Expression GenerateExpression(Constraint constraint)
        {
            switch (constraint)
            {
                default: return null;
            }
        }
    }
}
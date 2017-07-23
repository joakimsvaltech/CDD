using System.Collections.Generic;
using System.Linq;
using CDD.Core.Perpetual;
using CDD.Temporal.Transformations;
using Expression = CDD.Core.Temporal.Expression;

namespace CDD.Temporal
{
    public class Generator : Core.Generator
    {
        public Expression Generate(Constraint constraint)
        {
            if (constraint == null)
                return null;
            var transforms = GetTransforms(constraint);
            var expressions = transforms.Select(transform => transform.Apply());
            return expressions.FirstOrDefault(constraint.Apply);
        }

        private IEnumerable<Transform> GetTransforms(Constraint constraint)
        {
            switch (constraint)
            {
                case OutputConstraint output:
                    switch (output.Expression)
                    {
                        case Constant<int> constant:
                            yield return new AddReturnValue<int>(constant.Value);
                            break;
                        case Constant<string> constant:
                            yield return new AddReturnValue<string>(constant.Value);
                            break;
                    }
                    break;
            }
        }
    }
}
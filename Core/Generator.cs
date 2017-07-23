using CDD.Core.Perpetual;
using Expression = CDD.Core.Temporal.Expression;

namespace CDD.Core
{
    public interface Generator
    {
        Expression Generate(Constraint constraint);
    }
}
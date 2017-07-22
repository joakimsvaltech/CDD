using System.Collections.Generic;
using System.Linq;
using CDD.Core.Expressions;

namespace CDD.Core
{
    public class Program
    {
        private Dictionary<string, NamedConstraint> _constraints = new Dictionary<string, NamedConstraint>();
        private List<Expression> _expressions = new List<Expression>();

        public IEnumerable<NamedConstraint> Constraints
        {
            get => _constraints.Values;
            set
            {
                _constraints = value.ToDictionary(c => c.Name);
                ReGenerate();
            }
        }

        public IEnumerable<Expression> Expressions => _expressions;

        public void Add(NamedConstraint constraint)
        {
            _constraints.Add(constraint.Name, constraint);
            ReGenerate();
        }

        private void ReGenerate()
            => _expressions = Generator.Generate(_constraints.Values.Select(nc => nc.Constraint).ToArray())
                            .ToList();

        public NamedConstraint Remove(string name)
        {
            var constraint = _constraints[name];
            _constraints.Remove(name);
            ReGenerate();
            return constraint;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using CDD.Core.Expressions;

namespace CDD.Core
{
    public class Program
    {
        private readonly Generator _generator;
        private Dictionary<string, NamedConstraint> _constraints = new Dictionary<string, NamedConstraint>();
        private List<Expression> _expressions = new List<Expression>();

        public Program(Generator generator)
            =>_generator = generator;

        public IEnumerable<NamedConstraint> Constraints
        {
            get => _constraints.Values;
            set
            {
                _constraints = value.ToDictionary(c => c.Name);
                _expressions = Generate();
            }
        }

        public IEnumerable<Expression> Expressions => _expressions;

        public void Add(NamedConstraint constraint)
        {
            _constraints.Add(constraint.Name, constraint);
            _expressions = Generate();
        }

        private List<Expression> Generate()
            => Generator.Generate(_constraints.Values.Select(nc => nc.Constraint).ToArray())
                            .ToList();

        public NamedConstraint Remove(string name)
        {
            var constraint = _constraints[name];
            _constraints.Remove(name);
            return constraint;
        }
    }
}
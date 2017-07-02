using System.Collections.Generic;
using System.Linq;

namespace CDD.Core
{
    public class Interpreter
    {
        private Dictionary<string, Constraint> _constraints = new Dictionary<string, Constraint>();
        private List<Expression> _expressions = new List<Expression>();

        public IEnumerable<Constraint> Constraints
        {
            get => _constraints.Values;
            set => _constraints = value.ToDictionary(c => c.Name);
        }

        public IEnumerable<Expression> Expressions => _expressions;

        public void Add(Constraint constraint)
            => _constraints.Add(constraint.Name, constraint);

        public Constraint Remove(string name)
        {
            var constraint = _constraints[name];
            _constraints.Remove(name);
            return constraint;
        }
    }
}
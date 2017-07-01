using System;
using System.Collections.Generic;
using System.Linq;
using CDD.Core.Commands;
using CDD.Utility;

namespace CDD.Core
{
    public class Interpreter
    {
        private readonly Dictionary<string, Constraint> _constraints = new Dictionary<string, Constraint>();
        private readonly List<Expression> _expressions = new List<Expression>();
        private readonly Output _output;

        public Interpreter(Output output)
            => _output = output;

        public void ExecuteCommand(Command command)
        {
            switch (command)
            {
                case ListConstraintsCommand list:
                    ListConstraints(list);
                    break;
                case AddConstraintCommand add:
                    AddConstraint(add);
                    break;
                case RemoveConstraintCommand remove:
                    RemoveConstraint(remove);
                    break;
                case ReplaceConstraintCommand replace:
                    ReplaceConstraint(replace);
                    break;
                case RenameConstraintCommand rename:
                    RenameConstraint(rename);
                    break;
                default: throw new InvalidOperationException("Unknown command " + command);
            }
        }

        private void ListConstraints(ListConstraintsCommand list)
        {
            _output.Caption("Constraints by name: " + list.Pattern);
            var constraints = _constraints.Values
                .Where(c => c.Name.Contains(list.Pattern))
                .ToList();
            constraints.ForEach(c => _output.Text(c.ToString()));
        }

        private void AddConstraint(AddConstraintCommand add)
        {
            var constraint = new Constraint(add.Name, add.Constraint);
            _constraints.Add(add.Name, constraint);
        }

        private void RemoveConstraint(RemoveConstraintCommand remove)
        {
            throw new NotImplementedException();
        }

        private void ReplaceConstraint(ReplaceConstraintCommand replace)
        {
            throw new NotImplementedException();
        }

        private void RenameConstraint(RenameConstraintCommand rename)
        {
            throw new NotImplementedException();
        }

        public void PrintProgram()
        {
            _output.Caption("Program expressions:");
            _expressions.ForEach(expression => _output.Text(expression.ToString()));
        }

        public void PrintConstraints()
        {
            _output.Caption("Program constraints:");
            _constraints.Values.ForEach(_output.Text);
        }

        public Constraint GetConstraint(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
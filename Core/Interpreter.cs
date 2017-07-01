using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CDD.Core.Commands;
using CDD.Utility;

namespace CDD.Core
{
    public class Interpreter
    {
        private Dictionary<string, Constraint> _constraints = new Dictionary<string, Constraint>();
        private List<Expression> _expressions = new List<Expression>();
        private readonly Output _output;

        public Interpreter(Output output) => _output = output;

        private void ListConstraints(ListConstraints list)
        {
            _output.Caption("Constraints by name: " + list.Pattern);
            var constraints = _constraints.Values
                .Where(c => c.Name.Contains(list.Pattern))
                .ToList();
            constraints.ForEach(c => _output.Text(c.ToString()));
        }

        private void Execute(AddConstraint add)
        {
            var constraint = new Constraint(add.Name, add.Constraint);
            _constraints.Add(add.Name, constraint);
        }

        private void Execute(RemoveConstraint remove)
        {
            throw new NotImplementedException();
        }

        private void Execute(ReplaceConstraint replace)
        {
            throw new NotImplementedException();
        }

        private void Execute(RenameConstraint rename)
        {
            throw new NotImplementedException();
        }

        private void Execute(PrintProgram print)
        {
            _output.Caption("Program expressions:");
            _expressions.ForEach(expression => _output.Text(expression.ToString()));
            _output.Caption("Program constraints:");
            _constraints.Values.ForEach(_output.Text);
        }

        private void Execute(LoadProgram load)
            => _constraints = File.ReadAllLines(load.Name + ".prg")
            .Select(Parse).ToDictionary(c => c.Name);

        private void Execute(SaveProgram save)
            => File.WriteAllLines(save.Name + ".prg", _constraints.Values.Select(c => c.ToString()));

        private static Constraint Parse(string constraint)
        {
            var parts = constraint.Split(new[] {':'}, 2);
            return new Constraint(parts[0], parts[1].Trim());
        }

        public void Add(Constraint constraint)
            => _constraints.Add(constraint.Name, constraint);
    }
}
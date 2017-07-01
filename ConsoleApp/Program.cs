using System;
using System.Collections.Generic;
using System.Linq;
using CDD.Core;
using CDD.Core.Commands;
using CDD.Utility;

namespace CDD.ConsoleApp
{
    internal class Program
    {
        private static readonly Output Output = new ConsoleOutput();
        private static readonly Interpreter Interpreter = new Interpreter(Output);

        private static readonly IList<CommandBinding> CommandBindings = new[]
        {
            CommandBinding.Create<HelpCommand>("Help", ConsoleKey.H, ConsoleKey.Help),
            CommandBinding.Create<ExitCommand>("Exit", ConsoleKey.E, ConsoleKey.X, ConsoleKey.Q, ConsoleKey.Escape),
            CommandBinding.Create<PrintCommand>("Print program", ConsoleKey.P),
            CommandBinding.Create<ListConstraintsCommand>("List constraints", ConsoleKey.L),
            CommandBinding.Create<AddConstraintCommand>("Add constraint", ConsoleKey.Add, ConsoleKey.A),
            CommandBinding.Create<RemoveConstraintCommand>("Remove constraint", ConsoleKey.Subtract, ConsoleKey.D),
            CommandBinding.Create<ReplaceConstraintCommand>("Replace constraint", ConsoleKey.C),
            CommandBinding.Create<RenameConstraintCommand>("REnme constraint", ConsoleKey.R, ConsoleKey.N),
        };

        static void Main(string[] args)
        {
            Output.Caption("Constraint driven code-generator v. 0.1");
            Output.Text("Add, remove or change constraints");
            Output.Text("by command line commands.");
            Output.Text("Watch a program that follows");
            Output.Text("all constraints grow before your eyes!");
            Output.Text("Press 'H' for help");
            Output.Divider();
            while (ExecuteCommand(ReadCommand()))
            {
                Interpreter.PrintConstraints();
                Interpreter.PrintProgram();
            }
        }

        private static Command ReadCommand()
        {
            Console.Write(":> ");
            var keyInfo = Console.ReadKey();
            Console.WriteLine();
            return Interpret(keyInfo.Key) ?? new HelpCommand();
        }

        private static Command Interpret(ConsoleKey key)
            => CommandBindings
            .SingleOrDefault(c => c.Keys.Contains(key))
            ?.Command();

        private static bool ExecuteCommand(Command command)
        {
            if (command is ExitCommand)
                return false;
            if (command is HelpCommand)
                PrintHelp();
            else UpdateProgram(command);
            return true;
        }

        private static void PrintHelp()
        {
            Output.Caption("Commands:");
            CommandBindings.ForEach(Output.Text);
        }

        private static void UpdateProgram(Command command)
            => Interpreter.ExecuteCommand(ConfigureCommand(command));

        private static Command ConfigureCommand(Command command)
        {
            switch (command)
            {
                case ListConstraintsCommand list:
                    return ConfigureCommand(list);
                case AddConstraintCommand add:
                    return ConfigureCommand(add);
                case RemoveConstraintCommand remove:
                    return ConfigureCommand(remove);
                case ReplaceConstraintCommand replace:
                    return ConfigureCommand(replace);
                case RenameConstraintCommand rename:
                    return ConfigureCommand(rename);
                default: throw new InvalidOperationException("Unknown update program command: " + command);
            }
        }

        private static Command ConfigureCommand(ListConstraintsCommand list)
        {
            Console.WriteLine("List constraints");
            Console.Write("By name: ");
            list.Pattern = Console.ReadLine();
            return list;
        }

        private static Command ConfigureCommand(AddConstraintCommand add)
        {
            Console.WriteLine("Add constraint");
            Console.Write("Name: ");
            add.Name = Console.ReadLine();
            Console.Write("Constraint: ");
            add.Constraint = Console.ReadLine();
            return add;
        }

        private static Command ConfigureCommand(RemoveConstraintCommand remove)
        {
            Console.WriteLine("Remove constraint");
            Console.Write("Name: ");
            remove.Name = Console.ReadLine();
            return remove;
        }

        private static Command ConfigureCommand(ReplaceConstraintCommand replace)
        {
            Console.WriteLine("Replace constraint");
            Console.Write("Name: ");
            replace.Name = Console.ReadLine();
            Console.WriteLine("Old constraint: " + Interpreter.GetConstraint(replace.Name));
            Console.Write("New constraint: ");
            replace.NewConstraint = Console.ReadLine();
            return replace;
        }

        private static Command ConfigureCommand(RenameConstraintCommand rename)
        {
            Console.WriteLine("Rename constraint");
            Console.Write("Old name: ");
            rename.OldName = Console.ReadLine();
            Console.Write("New name: ");
            rename.NewName = Console.ReadLine();
            return rename;
        }

        private class CommandBinding
        {
            private readonly string _name;
            public readonly Func<Command> Command;
            public readonly ConsoleKey[] Keys;

            public static CommandBinding Create<TCommand>(string name, params ConsoleKey[] keys)
                where TCommand : Command, new()
            {
                return new CommandBinding(name, () => new TCommand(), keys);
            }

            private CommandBinding(string name, Func<Command> command, ConsoleKey[] keys)
            {
                _name = name;
                Command = command;
                Keys = keys;
            }

            public override string ToString() => $"{string.Join("/", Keys)}: {_name}";
        }
    }
}
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
        private static readonly Input Input = new ConsoleInput();
        private static readonly Interpreter Interpreter = new Interpreter(Output);

        private static readonly IList<CommandBinding> CommandBindings = new[]
        {
            CommandBinding.Create<HelpCommand>(ConsoleKey.H, ConsoleKey.Help),
            CommandBinding.Create<ExitCommand>(ConsoleKey.E, ConsoleKey.X, ConsoleKey.Q, ConsoleKey.Escape),
            CommandBinding.Create<PrintProgram>(ConsoleKey.P),
            CommandBinding.Create<ListConstraints>(ConsoleKey.L),
            CommandBinding.Create<AddConstraint>(ConsoleKey.Add, ConsoleKey.A),
            CommandBinding.Create<RemoveConstraint>(ConsoleKey.Subtract, ConsoleKey.D),
            CommandBinding.Create<ReplaceConstraint>(ConsoleKey.C),
            CommandBinding.Create<RenameConstraint>(ConsoleKey.N),
            CommandBinding.Create<SaveProgram>(ConsoleKey.S),
            CommandBinding.Create<LoadProgram>(ConsoleKey.O)
        };

        static void Main(string[] args)
        {
            Introduction();
            Interaction();
        }

        private static void Introduction()
        {
            Output.Caption("Constraint driven code-generator v. 0.1");
            Output.Text("Add, remove or change constraints");
            Output.Text("by command line commands.");
            Output.Text("Watch a program that follows");
            Output.Text("all constraints grow before your eyes!");
            Output.Text("Press 'H' for help");
            Output.Divider();
        }

        private static void Interaction()
        {
            Command command;
            do command = ReadCommand();
            while (Execute(command));
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

        private static bool Execute(Command command)
        {
            command.Configure(Output, Input);
            switch (command)
            {
                case ExitCommand exit:
                    return false;
                case HelpCommand help:
                    PrintHelp();
                    return true;
                case InterpreterCommand interpret:
                    interpret.Execute(Interpreter);
                    return true;
                default:
                    throw new InvalidOperationException("Unknown command: " + command);
            }
        }

        private static void PrintHelp()
        {
            Output.Caption("Commands:");
            CommandBindings.ForEach(Output.Text);
        }
    }
}
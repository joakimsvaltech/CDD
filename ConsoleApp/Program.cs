using System;
using System.Collections.Generic;
using System.Linq;
using CDD.Core.Spec;
using CDD.Perpetual;

namespace CDD.ConsoleApp
{
    using Core;
    using Core.Commands;
    using Utility;

    internal class Program
    {
        private static readonly Generator Generator = new GeneratorImpl();
        private static readonly Translator Translator = new TranslatorImpl();
        private static readonly Parser Parser = new ParserImpl(Translator);
        private static readonly Interactor Interactor = new ConsoleInteractor();
        private static readonly Core.Program Interpreter = new Core.Program(Generator);
        private static readonly Storage Storage = new FileStorage();

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
            Interactor.Caption("Constraint driven code-generator v. 0.1");
            Interactor.Output("Add, remove or change constraints");
            Interactor.Output("by command line commands.");
            Interactor.Output("Watch a program that follows");
            Interactor.Output("all constraints grow before your eyes!");
            Interactor.Output("Press 'H' for help");
            Interactor.Divider();
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
            return Interpret(keyInfo.Key);
        }

        private static Command Interpret(ConsoleKey key)
            => CommandBindings
            .SingleOrDefault(c => c.Keys.Contains(key))
            ?.Command() ?? new HelpCommand();

        private static bool Execute(Command command)
        {
            command.Configure(Interactor, Storage, Parser);
            switch (command)
            {
                case ExitCommand _:
                    return false;
                case HelpCommand _:
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
            Interactor.Caption("Commands:");
            CommandBindings.ForEach(Interactor.Output);
        }
    }
}
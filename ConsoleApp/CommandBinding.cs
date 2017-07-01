using System;
using CDD.Core.Commands;
using CDD.Utility;

namespace CDD.ConsoleApp
{
    internal class CommandBinding
    {
        private readonly string _name;
        public readonly Func<Command> Command;
        public readonly ConsoleKey[] Keys;

        public static CommandBinding Create<TCommand>(params ConsoleKey[] keys)
            where TCommand : Command, new()
        {
            return new CommandBinding(typeof(TCommand).Name.CamelCaseToWords(), () => new TCommand(), keys);
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
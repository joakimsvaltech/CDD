using System;
using CDD.Core;

namespace CDD.ConsoleApp
{
    public class ConsoleInput : Input
    {
        public string Text() => Console.ReadLine();
    }
}

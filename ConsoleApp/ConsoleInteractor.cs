using System;

namespace CDD.ConsoleApp
{
    using Core;
    using Utility;

    public class ConsoleInteractor : Interactor
    {
        public string Input() => Console.ReadLine();
        public void Output<T>(T obj) => Console.WriteLine($"{obj}");
        public void Label(string label) => Console.Write($"{label}: ");
        public void Divider() => Console.WriteLine(new string('-', 30));
        public void Caption(string caption)
            => new[] {"", caption, new string('=', caption.Length)}
            .ForEach(Console.WriteLine);
    }
}
using System;
using CDD.Core;

namespace CDD.ConsoleApp
{
    public class ConsoleInteractor : Interactor
    {
        public string Input() => Console.ReadLine();

        public void Output<T>(T obj)
            => Console.WriteLine($"{obj}");

        public void Caption(string caption)
        {
            Console.WriteLine();
            Console.WriteLine(caption);
            Console.WriteLine(new string('=', caption.Length));
        }

        public void Divider()
            => Console.WriteLine("----------------------------");

        public void Label(string label)
            => Console.Write($"{label}: ");
    }
}

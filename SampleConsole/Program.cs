using System;

namespace SampleConsole
{
    internal class Program
    {
        private static void Main()
        {
            Action action = MultiThreadDictionary.RunDictionary;

            Console.WriteLine($"Running: {action.Method.DeclaringType.Name}.{action.Method.Name}");
            action();
        }
    }
}
using System;
using Buzz;

namespace BuzzApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var phrase = Generator.Buzz();
            Console.WriteLine($"Phrase: {phrase}.");
        }
    }
}

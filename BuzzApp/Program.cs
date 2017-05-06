using System;
using Buzz;

namespace BuzzApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = BuzzGeneratorFactory.Create();
            var phrase = generator.Buzz();
            Console.WriteLine($"Phrase: {phrase}.");
        }
    }
}

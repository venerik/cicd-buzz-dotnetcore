using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Buzz
{
    public class Generator
    {
        private static string[] _buzz = { "continuous testing", "continuous integration", "continuous deployment", "continuous improvement", "devops" };
        private static string[] _adjectives = { "complete", "modern", "self-service", "integrated", "end-to-end" };
        private static string[] _adverbs = { "remarkably", "enormously", "substantially", "significantly", "seriously" };
        private static string[] _verbs = { "accelerates", "improves", "enhances", "revamps", "boosts" };

        private static Random _rnd = new Random();

        public string Buzz()
        {
            var buzzTerms = Sample(_buzz, 2);
            var phrase = string.Join(" ", Sample(_adjectives), buzzTerms[0], Sample(_adverbs), Sample(_verbs), buzzTerms[1]);
            return ToTitleCase(phrase);
        }

        public string Sample(IList<string> values)
        {
            var index = _rnd.Next(values.Count);
            return values[index];
        }

        public IList<string> Sample(IList<string> values, int size)
        {
            var samples = new List<string>();

            if(size < 1)
            {
                return samples;
            }

            if(size == values.Count)
            {
                return values;
            }

            var source = new List<string>(values);
            while(samples.Count != size)
            {
                var value = Sample(source);
                samples.Add(value);
                source.Remove(value);
            }

            return samples;
        }

        private static string ToTitleCase(string value)
        {
            return Regex.Replace(value, @"\b(\w)", m => m.Value.ToUpper());
        }
    }
}

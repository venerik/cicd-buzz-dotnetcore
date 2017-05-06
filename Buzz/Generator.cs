using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Buzz
{
    public class Generator
    {
        private static string[] _buzz = { 
            "continuous testing", 
            "continuous integration", 
            "continuous deployment", 
            "continuous improvement", 
            "devops" };
        private static string[] _adjectives = { 
            "complete", 
            "modern", 
            "self-service", 
            "integrated", 
            "end-to-end" };
        private static string[] _adverbs = { 
            "remarkably", 
            "enormously", 
            "substantially", 
            "significantly", 
            "seriously" };
        private static string[] _verbs = { 
            "accelerates", 
            "improves", 
            "enhances", 
            "revamps", 
            "boosts" };

        private static Random _rnd = new Random();

        public string Buzz()
        {
            string phrase = GeneratePhrase();
            return phrase.ToTitleCase();
        }

        public string Sample(IList<string> values)
        {
            if(values == null || !values.Any())
            {
                return string.Empty;
            }

            var index = _rnd.Next(values.Count);
            return values[index];
        }

        public IList<string> Sample(IList<string> values, int size)
        {
            if (values == null || !values.Any() || size < 1)
            {
                return new List<string>();
            }

            if (size >= values.Count)
            {
                return values;
            }

            return GetSamples(values, size);
        }

        private List<string> GetSamples(IList<string> values, int size)
        {
            var samples = new List<string>();
            var source = new List<string>(values);
            while (samples.Count != size)
            {
                var value = Sample(source);
                samples.Add(value);
                source.Remove(value);
            }

            return samples;
        }

        private string GeneratePhrase()
        {
            var buzzTerms = _buzz.Sample(2).ToList();
            return string.Join(
                " ", 
                _adjectives.Sample(), 
                buzzTerms[0], 
                _adverbs.Sample(), 
                _verbs.Sample(), 
                buzzTerms[1]);
        }
    }
}

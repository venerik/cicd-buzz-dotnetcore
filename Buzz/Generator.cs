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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Buzz
{
    public static class IEnumerableExtensions
    {
        private static Random _rnd = new Random();

        public static T Sample<T>(this IEnumerable<T> values)
        {
            return Sample(values, 1).First();
        }

        public static IEnumerable<T> Sample<T>(this IEnumerable<T> values, int size)
        {
            if(!values.Any())
            {
                throw new InvalidOperationException("Collection empty.");
            }

            if (size < 1)
            {
                return new List<T>();
            }

            if (size >= values.Count())
            {
                return values;
            }

            return GetSamples(values, size);
        }
        private static IEnumerable<T> GetSamples<T>(IEnumerable<T> values, int size)
        {
            var samples = new List<T>();
            var source = new List<T>(values);
            while (samples.Count != size)
            {
                var index = _rnd.Next(source.Count());
                var value = source[index];
                samples.Add(value);
                source.Remove(value);
            }
            return samples;
        }
    }
}

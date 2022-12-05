using System;
using System.Collections.Generic;

namespace MeanMode
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        public static bool MeanMode(int[] array)
        {
            return computeMode(array) == computeAverage(array);
        }

        // TODO
        private static double computeAverage(int[] array)
        {
            int i = 0;
            int sum = 0;
            foreach(var num in array)
            {
                sum += num;
                i += 1;
            }
            return (sum / i);
        }

        // TODO
        private static double? computeMode(int[] array)
        {
            var numbers = new Dictionary<int, int>();
            foreach(var num in array)
            {
                if (numbers.ContainsKey(num))
                {
                    numbers[num] += 1;
                }
                else
                {
                    numbers[num] = 1;
                }
            }
            int max = 0;
            foreach (var val in numbers.Values)
            {
                if (val > max)
                {
                    max = val;
                }
            }
            var modes = new List<int>();
            foreach (var key in numbers.Keys)
            {
                if (numbers[key] == max)
                {
                    modes.Add(key);
                }
            }
            if (modes.Count == 1)
            {
                return modes[0];
            }
            else
            {
                return null;
            }
        }
    }
}

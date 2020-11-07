using System;
using System.Collections.Generic;
using System.Linq;

namespace Sela_Arrays
{
    public class RandomArrayGenerator
    {
        private static Random random = new Random();

        public static int[] GetRandomArray(int size, int minValue, int maxValue)
        {
            int[] arr = new int[size];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(minValue, maxValue + 1);
            }

            return arr;
        }

        public static List<int> GetArbitraryRandomArray(int numberOfZeros, int minValue, int maxValue)
        {
            if (minValue > 0 || maxValue < 0)
            {
                return null;
            }

            List<int> arr = new List<int>();
            int currentNumberOfZeros = 0;
            while (currentNumberOfZeros < numberOfZeros)
            {
                arr.Add(random.Next(minValue, maxValue + 1));
                if (arr.Last() == 0)
                {
                    currentNumberOfZeros++;
                }
            }
            return arr;
        }
    }
}

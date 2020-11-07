using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumbers
{
    public static class RandomArrayGenerator
    {
        private static Random Random = new Random();

        public static int[] GetRandomArray(int size, int minValue, int maxValue)
        {
            int[] arr = new int[size];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Random.Next(minValue, maxValue + 1);
            }

            return arr;
        }

        public static List<int> GetArbitraryRandomArray(int numberOfZeros, int minValue, int maxValue)
        {
            if(minValue > 0 || maxValue < 0)
            {
                return null;
            }

            List<int> arr = new List<int>();
            int currentNumberOfZeros = 0;
            while(currentNumberOfZeros < numberOfZeros)
            {
                arr.Add(Random.Next(minValue, maxValue + 1));
                if (arr.Last() == 0)
                {
                    currentNumberOfZeros++;
                }
            }
            return arr;
        }
    }
}

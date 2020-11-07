using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sela_Arrays
{
    public static class IntArrayHelper
    {
        public static int ElementCount(this int[] array, int element)
        {
            return array.Where(x => x == element).Count();
        }

        public static int IdenticalElementCount(this int[] array)
        {
            return array.SkipLast(1).Where((element, index) => element == array[index + 1]).Count();
        }

        public static int EvenCount(this int[] array)
        {
            return array.Where(x => x % 2 == 0).Count();
        }

        public static IEnumerable<int> Even(this int[] array)
        {
            return array.Where(x => x % 2 == 0);
        }

        public static IEnumerable<int> Odd(this int[] array)
        {
            return array.Where(x => x % 2 == 1);
        }

        public static List<int> ElementDistance(this int[] array, int element)
        {
            var distances = new List<int>();
            int last = -1;
            for (int i = 0; i < array.Count(); i++)
            {
                if (array[i] == element)
                {
                    distances.Add(i - last - 1);
                    last = i;
                }
            }
            return distances;
        }
    }
}

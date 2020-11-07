using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumbers
{
    public static class IntArrayHelper
    {

        public static int ElementCount(this int[] array, int element)
        {
            return array.Where(x => x == element).Count();
        }

        public static int IdenticalElementCount(this int[] array)
        {
            return array.SkipLast(1).Where((element,index) => element == array[index+1]).Count();
        }

        public static List<int> ElementDistance(this int[] array, int element)
        {
            var distances = new List<int>();
            int last = -1;
            for (int i = 0; i < array.Count(); i++)
            {
                if(array[i] == element)
                {
                    distances.Add(i - last - 1);
                    last = i;
                }
            }
            return distances;
        }
    }
}

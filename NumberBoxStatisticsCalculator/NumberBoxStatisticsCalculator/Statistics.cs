using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberBoxStatisticsCalculator
{
    public class Statistics
    {

        public int Count { get; set; }
        public double Average { get; set; }
        public double Median { get; set; }
        public double Sum { get; set; }
        public double Mininum { get; set; }
        public double Maximum { get; set; }

        internal static Statistics Calculate(IEnumerable<double> enumerable)
        {
            var count = enumerable.Count();
            return new Statistics
            {
                Count = count,
                Average = enumerable.Average(x => x),
                Median = enumerable.OrderBy(x => x).ElementAt(count / 2),
                Sum = enumerable.Sum(x=>x),
                Mininum = enumerable.Min(),
                Maximum = enumerable.Max()
            };
        }

        internal static Statistics Empty = new Statistics { Count = 0, Average = double.NaN, Sum = double.NaN, Maximum = double.NaN, Median = double.NaN, Mininum = double.NaN };

    }
}

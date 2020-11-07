using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    public class DiceResult
    {
        public int NumberOfDice { get; set; }
        public double Average { get; set; }
        public int Sum { get; set; }

        public override string ToString()
        {
            return $"Sum: {Sum}, Average: {Average}, Number of Dices: {NumberOfDice}";
        }
    }
}

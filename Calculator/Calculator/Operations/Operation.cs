using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operations
{
    public class Operation
    {
        public static Operation Addition = new Operation((a, b) => a + b);

        public Uri Icon { get; }

        public OperationOrder Order { get; }

        public Func<double, double, double> Func { get; }
        
        private Operation(Func<double, double, double> func)
        {
            Func = func;
        }
    }
}

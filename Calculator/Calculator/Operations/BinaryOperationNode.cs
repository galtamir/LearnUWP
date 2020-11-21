using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operations
{
    class BinaryOperationNode : IOperationNode
    {
        public IOperationNode Left { get; set; }
        public IOperationNode Rigth { get; set; }

        public IOperationNode Parent { get; private set; }

        private Func<double, double, double> Func;

        public double Evaluate()
        {
            return Func(Left.Evaluate(), Rigth.Evaluate());
        }

        public bool TryAdd(IOperationNode operation)
        {
            if(Rigth == null)
            {
                Rigth = operation;
                operation.Parent = this;
            }
        }
    }
}

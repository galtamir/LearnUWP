using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operations
{
    class RootNodeOperation : IOperationNode
    {
        public IOperationNode Parent => this;

        public IOperationNode Child { get; set; }

        public double Evaluate()
        {
            return Child.Evaluate();
        }

        public bool TryAdd(IOperationNode operation)
        {
            throw new NotImplementedException();
        }
    }
}

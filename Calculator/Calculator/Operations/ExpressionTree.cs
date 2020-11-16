using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operations
{
    class ExpressionTree
    {
        private IOperationNode root;
        private IOperationNode last;

        public ExpressionTree()
        {
            root = new RootNodeOperation();
            last = root;
        }

        public void Add(IOperationNode operation)
        {
            if (last.TryAdd(operation))
            {
                last = operation;
            }
        }

        public double Evaluate()
        {
            return root.Evaluate();
        }
    }
}

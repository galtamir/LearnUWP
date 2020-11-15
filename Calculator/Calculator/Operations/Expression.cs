using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operations
{
    public class Expression
    {
        public double Value { get; private set; }

        private List<IOperation> operations;


        public Expression()
        {
            operations = new List<IOperation>();
        }

        public void Undo()
        {

        }

        public void AddOperation(IOperation operation)
        {
            operations.Add(operation);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

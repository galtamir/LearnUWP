using System;

namespace Calculator.Operations
{
    public class OperationEventArgs : EventArgs
    {
        public IOperation Operation { get; }

        public OperationEventArgs(IOperation operation)
        {
            Operation = operation;
        }
    }
}
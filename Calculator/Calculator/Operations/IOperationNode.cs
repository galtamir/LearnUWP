namespace Calculator.Operations
{
    internal interface IOperationNode
    {
        double Evaluate();

        IOperationNode Parent { get; }

        bool TryAdd(IOperationNode operation);
    }
}
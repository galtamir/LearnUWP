namespace Calculator.Operations
{
    internal class NumberNode : IOperationNode
    {
        private int v;

        public NumberNode(int v)
        {
            this.v = v;
        }

        public IOperationNode Parent => throw new System.NotImplementedException();

        public double Evaluate()
        {
            return v;
        }

        public bool TryAdd(IOperationNode operation)
        {
            throw new System.NotImplementedException();
        }
    }
}
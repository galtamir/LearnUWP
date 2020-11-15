using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Calculator.Operations
{
    class CalculatorButton : Button
    {
        private IOperation Operation;

        public delegate void CalculatorInpotEventHandler(object sender, OperationEventArgs e);
        public event CalculatorInpotEventHandler OnCalculatorCuttonClicked;

        public CalculatorButton(IOperation operation) : base()
        {
            Operation = operation;
            Click += (a, b) => OnCalculatorCuttonClicked(this, new OperationEventArgs(Operation));
            Background = Operation.Background;
            Content = Operation.Content;

            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            Margin = new Thickness { Bottom = 5, Top = 5, Left = 5, Right = 5 };
        }
    }
}

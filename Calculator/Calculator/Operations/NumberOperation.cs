using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Calculator.Operations
{
    public class NumberOperation : IOperation
    {
        public Brush Background => new SolidColorBrush(Windows.UI.Colors.Wheat);

        public object Content { get; }

        public NumberOperation(int i)
        {
            Content = i;
        }
    }
}

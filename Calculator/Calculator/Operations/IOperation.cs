using Windows.UI.Xaml.Media;

namespace Calculator.Operations
{
    public interface IOperation
    {
        Brush Background { get; }
        object Content { get; }
        int
    }
}
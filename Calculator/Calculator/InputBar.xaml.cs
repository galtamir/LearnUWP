using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Calculator
{
    public sealed partial class InputBar : UserControl
    {
        public delegate void NumberButtonInpotEventHandler(object sender, AppendNumberEventArgs e);
        public event NumberButtonInpotEventHandler OnInputAdded;
        public event NumberButtonInpotEventHandler OnOperationClicked;
        public event NumberButtonInpotEventHandler OnEqualClicked;

        private static readonly Brush numberColor = new SolidColorBrush(Windows.UI.Colors.Wheat);
        private static readonly Brush operationColor = new SolidColorBrush(Windows.UI.Colors.FloralWhite);

        public InputBar()
        {
            this.InitializeComponent();
            OnInputAdded += (x,y)=> { };

            CreatOperationButton(".",4,1);

            CreatOperationButton("^",0,2);
            CreatOperationButton("+",4,3);
            CreatOperationButton("-",3,3);
            CreatOperationButton("*" , 2, 3);

            CreatOperationButton("/", 1, 3);

            CreatNumberButton(0, 4, 0);
            for (int i = 1; i <= 9; i++)
            {
                CreatNumberButton(i, 4 - ((i + 2) / 3), (((i - 1) % 3) + 3) % 3);
            }
            CreatEqualButton(4, 2);
        }

        private void CreatEqualButton(int row, int column)
        {
            var b = CreatButton("=", row, column, numberColor);
            b.Click += EqualeClicked;
            
        }

        private void CreatNumberButton(int i, int row, int column)
        {
            var b = CreatButton(i.ToString(), row, column, numberColor);
            b.Click += InputButtonClicked;
        }

        private void CreatOperationButton(string i, int row, int column)
        {
            var b = CreatButton(i, row, column, operationColor);
            b.Click += OperationClicked;
        }

        private Button CreatButton(string i, int row, int column, Brush background)
        {
            var b = new Button
            {
                FontSize = 42,
                Background = background,
                Content = i,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness { Bottom = 5, Top = 5, Left = 5, Right = 5 }
            };
            MainPanel.Children.Add(b);

            Grid.SetRow(b, row);
            Grid.SetColumn(b, column);
            return b;

        }

        private void InputButtonClicked(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            OnInputAdded(button, new AppendNumberEventArgs((string)button.Content));
        }

        private void OperationClicked(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            OnInputAdded(button, new AppendNumberEventArgs((string)button.Content));
        }

        private void EqualeClicked(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            OnInputAdded(button, new AppendNumberEventArgs((string)button.Content));
        }

        public class AppendNumberEventArgs : EventArgs
        {
            public AppendNumberEventArgs(string toAppend)
            {
                ToAppent = toAppend;
            }

            public string ToAppent { get; set; }
        }
    }
}

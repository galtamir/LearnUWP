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

        private static readonly Brush numberColor = new SolidColorBrush(Windows.UI.Colors.Blue);
        private static readonly Brush operationColor = new SolidColorBrush(Windows.UI.Colors.Blue);

        public InputBar()
        {
            this.InitializeComponent();
            OnInputAdded += (x,y)=> { };

            CreatButton(".",4,1, numberColor);

            CreatButton("^",4,2, operationColor);
            CreatButton("+",4,3, operationColor);
            CreatButton("-",3,3, operationColor);
            CreatButton("*" , 2, 3, operationColor);

            CreatButton("/", 1, 3, operationColor);

            CreatButton("0", 4, 0, numberColor);
            for (int i = 1; i <= 9; i++)
            {
                CreatButton(i.ToString(), 4 - ((i + 2) / 3), (((i - 1) % 3) + 3) % 3, numberColor);
            }
           
        }

        private Button CreatButton(string i, int row, int column, Brush background)
        {
            var b =  new Button
            {
                FontSize = 42,
                Background = background,
                Content = i,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness { Bottom = 5, Top=5, Left=5, Right = 5 }
            };
            b.Click += InputButtonClicked;
            MainPanel.Children.Add(b);

            Grid.SetRow(b, row);
            Grid.SetColumn(b, column);

            return b;
        }

        private void InputButtonClicked(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            OnInputAdded(this, new AppendNumberEventArgs((string)button.Content));
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

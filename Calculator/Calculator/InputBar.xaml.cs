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
        public InputBar()
        {
            this.InitializeComponent();

            Button b = CreatButton(0);

            MainPanel.Children.Add(b);
            Grid.SetRow(b, 4);
            Grid.SetColumn(b, 1);

            for (int i = 1; i <= 9; i++)
            {
                b = CreatButton(i);

                MainPanel.Children.Add(b);
                Grid.SetRow(b, 3 - ((i - 1) / 3));
                Grid.SetColumn(b, (((i - 1) % 3) + 3) % 3);
            }
        }

        private static Button CreatButton(int i)
        {
            var b =  new Button
            {
                Content = i,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness { Bottom = 5, Top=5, Left=5, Right = 5 }
            };
            b.Click += B_Click;
            return b;
        }

        private static void B_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        public Board()
        {
            InitializeComponent();
            for (int i = 0; i < 8; i++)
            {
                ChessBoard.ColumnDefinitions.Add(new ColumnDefinition());
                ChessBoard.RowDefinitions.Add(new RowDefinition());
            }
            var lite = new SolidColorBrush(Color.FromArgb(255, 240, 240, 220));
            var dark = new SolidColorBrush(Color.FromArgb(255, 80, 50, 30));
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var r = new Rectangle
                    {
                        Fill = (i + j) % 2 == 0 ? lite : dark,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch
                    };

                    ChessBoard.Children.Add(r);
                    Grid.SetColumn(r, j);
                    Grid.SetRow(r, i);
                }
            }
        }
    }
}

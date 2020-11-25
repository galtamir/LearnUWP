using DogeGameLogics.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameUI_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        private void CreateNewGame(object sender, RoutedEventArgs e)
        {
            var board = GameLogics.LogicsBuilder().
                SetHeigth((int)HeigthSlider.Value).
                SetWidth((int)WidthSlider.Value).
                Cyclic(CyclicCheckBox.IsChecked.Value).
                Build().GenerateBoard();
        }
    }
}

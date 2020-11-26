using DogeGameLogics;
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
        private Dictionary<int, Shape> _livePieces;

        public MainWindow()
        {
            InitializeComponent();
            MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        private async void CreateNewGame(object sender, RoutedEventArgs e)
        {

            int heigth = (int)HeigthSlider.Value;
            int width = (int)WidthSlider.Value;
            ClrearBoard();
            CreateBoard(heigth, width);

            var board = GameLogics.LogicsBuilder().
                SetHeigth(heigth).
                SetWidth(width).
                Cyclic(CyclicCheckBox.IsChecked.Value).
                Build().GenerateBoard();
            board.OnPieceMove += Board_OnPieceMove;

            CreatePlayers(board.State);
            
            var engine = new GameEngine(board, 800);

            await engine.StartGame();
        }

        private void CreatePlayers(Dictionary<int, Position> state)
        {
            _livePieces = new Dictionary<int, Shape>();

            foreach (var id in state.Keys)
            {
                var position = state[id];
                Ellipse e = new Ellipse();
                e.Height = 50; e.Width = 50;
                e.HorizontalAlignment = HorizontalAlignment.Stretch;
                e.VerticalAlignment = VerticalAlignment.Stretch;
                GamePanel.Children.Add(e);
                Grid.SetColumn(e, position.Width);
                Grid.SetRow(e, position.Height);
                if (id < 0) // player
                {
                    e.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }
                else
                {
                    e.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                }

                _livePieces.Add(id, e);
            }
        }

        private void Board_OnPieceMove(object sender, PiecesMoveArgs e)
        {
            foreach (var item in _livePieces.Keys)
            {
                if (e.Positions.ContainsKey(item))
                {
                    Grid.SetColumn(_livePieces[item], e.Positions[item].Width);
                    Grid.SetRow(_livePieces[item], e.Positions[item].Height);
                }
                else
                {
                    GamePanel.Children.Remove(_livePieces[item]);
                }
            }
        }

        private void ClrearBoard()
        {
            if(GamePanel.ColumnDefinitions.Count > 0)
            {
                GamePanel.ColumnDefinitions.RemoveRange(0, GamePanel.ColumnDefinitions.Count);
                GamePanel.RowDefinitions.RemoveRange(0, GamePanel.RowDefinitions.Count);
            }

        }

        private void CreateBoard(int higth, int width)
        {
            for (int i = 0; i < width; i++)
            {
                GamePanel.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < higth; i++)
            {
                GamePanel.RowDefinitions.Add(new RowDefinition());
            }
        }
    }
}

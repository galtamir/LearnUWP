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
        private GameEngine _engine;
        private ToCanvasTramsformer _tramsformer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void CreateNewGame(object sender, RoutedEventArgs e)
        {

            int heigth = (int)HeigthSlider.Value;
            int width = (int)WidthSlider.Value;
            _tramsformer = new ToCanvasTramsformer(HeigthSlider.Value, WidthSlider.Value, GamePanel.ActualHeight, GamePanel.ActualWidth);
            ClrearBoard();

            var board = GameLogics.LogicsBuilder().
                SetHeigth(heigth).
                SetWidth(width).
                Cyclic(CyclicCheckBox.IsChecked.Value).
                BuildLogics().GenerateBoard();

            board.OnPieceMove += OnPieceMove;

            CreatePlayers(board.State);

            _engine = new GameEngine(board, (int)Speed.Value);

            await _engine.StartGame();
        }

        private void CreatePlayers(Dictionary<int, Position> state)
        {
            _livePieces = new Dictionary<int, Shape>();

            foreach (var id in state.Keys)
            {
                var position = state[id];
                Shape e = new Ellipse();
                e.Height = 10; e.Width = 10;

                GamePanel.Children.Add(e);
                Canvas.SetLeft(e, _tramsformer.ToLeft(position.Width));
                Canvas.SetTop(e, _tramsformer.ToTop(position.Height));

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

        private void OnPieceMove(object sender, PiecesMoveArgs e)
        {
            foreach (var item in _livePieces.Keys)
            {
                if (e.Positions.ContainsKey(item))
                {
                    Canvas.SetLeft(_livePieces[item], _tramsformer.ToLeft(e.Positions[item].Width));
                    Canvas.SetTop(_livePieces[item], _tramsformer.ToTop(e.Positions[item].Height));
                }
                else
                {
                    GamePanel.Children.Remove(_livePieces[item]);
                }
            }
        }

        private void ClrearBoard()
        {
            if(_livePieces!=null)
                foreach (var item in _livePieces.Values)
                {
                    GamePanel.Children.Remove(item);
                }
            if (_engine != null)
            {
                _engine.Cancel();
            }
        }

        private void OnTextInputKeyDown(object sender, KeyEventArgs e)
        {
            _engine.Direction = e.Key switch
            {
                Key.Up => Direction.Up,
                Key.Right => Direction.Right,
                Key.Left => Direction.Left,
                Key.Down => Direction.Down,
                _ => _engine.Direction
            };
        }

        private void GamePanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            _tramsformer = new ToCanvasTramsformer(HeigthSlider.Value, WidthSlider.Value, e.NewSize.Height, e.NewSize.Width);
        }
    }
}

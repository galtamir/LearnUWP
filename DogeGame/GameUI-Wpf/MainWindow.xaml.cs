using DodgeGameLogics;
using DodgeGameLogics.Logic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        private const int objectSize = 10;
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
            var board = GameLogics.LogicsBuilder().
                SetHeigth(heigth).
                SetWidth(width).
                Cyclic(CyclicCheckBox.IsChecked.Value).
                NumberOfEnemies((int)Enemies.Value).
                BuildLogics().GenerateBoard();
            await StartGame(board);
        }


        private async Task StartGame(GameBoard board)
        {
            _tramsformer = new ToCanvasTramsformer(objectSize, HeigthSlider.Value, WidthSlider.Value, GamePanel.ActualHeight, GamePanel.ActualWidth);
            ClrearBoard();

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
                e.Height = objectSize; e.Width = objectSize;

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
            _tramsformer = new ToCanvasTramsformer(objectSize ,HeigthSlider.Value, WidthSlider.Value, e.NewSize.Height, e.NewSize.Width);
        }

        private async void SaveGame(object sender, RoutedEventArgs e)
        {
            _engine?.Pause();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // Show open file dialog box
            var result = saveFileDialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = saveFileDialog.FileName;
                await File.WriteAllTextAsync(filename, _engine.SaveGame());
            }
            
        }

        private async void LoadGame(object sender, RoutedEventArgs e)
        {
            _engine?.Pause();
            OpenFileDialog dlg = new OpenFileDialog();
            // Show save file dialog box
            var result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                var state = JsonSerializer.Deserialize<State>(
                    await File.ReadAllTextAsync(dlg.FileName));
                HeigthSlider.Value = state.BoardHeigth;
                WidthSlider.Value = state.BoardWidth;
                var board = GameLogics.
                    LogicsBuilder().
                    FromSate(state).
                    GenerateBoard();
                await StartGame(board);
            }
        }

        private void PausePlayGame(object sender, RoutedEventArgs e)
        {
            _engine?.PausePlay();
        }
    }
}

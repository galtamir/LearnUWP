using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DodgeGameLogics;
using DodgeGameLogics.Logic;

namespace FormsUI
{
    public partial class Form1 : Form
    {
        private const int objectSize = 10;
        private const int boardHeigth = 100;
        private const int boardWidth = 100;
        private const int speed = 150;

        private Dictionary<int, Control> _livePieces;
        private GameEngine _engine;
        private ToCanvasTramsformer _tramsformer;

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;


            KeyDown += OnBrowserKeyDown;
            KeyUp += OnBrowserKeyUp;
        }

        private void OnBrowserKeyUp(object sender, KeyEventArgs e)
        {
            _engine.Direction = e.KeyData switch
            {
                Keys.Up => Direction.Up,
                Keys.Right => Direction.Right,
                Keys.Left => Direction.Left,
                Keys.Down => Direction.Down,
                _ => _engine.Direction
            };
        }

        private void OnBrowserKeyDown(object sender, KeyEventArgs e)
        {
            _engine.Direction = e.KeyData switch
            {
                Keys.Up => Direction.Up,
                Keys.Right => Direction.Right,
                Keys.Left => Direction.Left,
                Keys.Down => Direction.Down,
                _ => _engine.Direction
            };
        }

        private async void SreateNewGame(object sender, EventArgs e)
        {
            var board = GameLogics.LogicsBuilder().
                SetHeigth(boardHeigth).
                SetWidth(boardWidth).
                Cyclic(true).
                NumberOfEnemies(6).
                BuildLogics().GenerateBoard();
            await StartGame(board);
        }

        private async Task StartGame(GameBoard board)
        {
            _tramsformer = new ToCanvasTramsformer(objectSize, boardWidth, boardWidth, gamePanel.Size.Height, gamePanel.Size.Width);
            ClrearBoard();

            board.OnPieceMove += OnPieceMove;

            CreatePlayers(board.State);

            _engine = new GameEngine(board, speed);

            await _engine.StartGame();
        }

        private void ClrearBoard()
        {
            if (_livePieces != null)
                foreach (var item in _livePieces.Values)
                {
                    gamePanel.Controls.Remove(item);
                }
            if (_engine != null)
            {
                _engine.Cancel();
            }
        }

        private void OnPieceMove(object sender, PiecesMoveArgs e)
        {
            foreach (var item in _livePieces.Keys)
            {
                if (e.Positions.ContainsKey(item))
                {
                    _livePieces[item].Location = new Point(
                        (int)_tramsformer.ToLeft(e.Positions[item].Width),
                        (int)_tramsformer.ToTop(e.Positions[item].Height));
                }
                else
                {
                    gamePanel.Controls.Remove(_livePieces[item]);
                }
            }
        }

        private void CreatePlayers(Dictionary<int, Position> state)
        {
            _livePieces = new Dictionary<int, Control>();

            foreach (var id in state.Keys)
            {
                var position = state[id];
                PictureBox e = new PictureBox();
                e.Height = objectSize; e.Width = objectSize;

                gamePanel.Controls.Add(e);
                e.Location = new Point((int)_tramsformer.ToLeft(position.Width),
                    (int)_tramsformer.ToTop(position.Height));

                if (id < 0) // player
                {
                    e.BackColor = Color.Green;
                }
                else
                {
                    e.BackColor = Color.Red;
                }

                _livePieces.Add(id, e);
            }
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void SaveGame(object sender, EventArgs e)
        {
            _engine?.Pause();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // Show open file dialog box
            var result = saveFileDialog.ShowDialog();

            // Process open file dialog box results
            if (result == DialogResult.OK)
            {
                // Open document
                string filename = saveFileDialog.FileName;
                await File.WriteAllTextAsync(filename, _engine.SaveGame());
            }
        }

        private void PlayPause(object sender, EventArgs e)
        {
            _engine?.PausePlay();
        }

        private async void LoadGame(object sender, EventArgs e)
        {
            _engine?.Pause();
            OpenFileDialog dlg = new OpenFileDialog();
            // Show save file dialog box
            var result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == DialogResult.OK)
            {
                var state = JsonSerializer.Deserialize<State>(
                    await File.ReadAllTextAsync(dlg.FileName));
                //HeigthSlider.Value = state.BoardHeigth;
                //WidthSlider.Value = state.BoardWidth;
                var board = GameLogics.
                    LogicsBuilder().
                    FromSate(state).
                    GenerateBoard();
                await StartGame(board);
            }
        }
    }
}

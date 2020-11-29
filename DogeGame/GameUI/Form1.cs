using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DogeGameLogics;
using DogeGameLogics.Logic;
using FormsUI;

namespace GameUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NweGame(object sender, EventArgs e)
        {
            int heigth = 200;
            int width = 200;
            var board = GameLogics.LogicsBuilder().
                SetHeigth(heigth).
                SetWidth(width).
                Cyclic(true).
                NumberOfEnemies(10).
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

        private void SaveGame(object sender, EventArgs e)
        {

        }

        private void LoadGame(object sender, EventArgs e)
        {

        }

        private void Pause(object sender, EventArgs e)
        {

        }
    }
}

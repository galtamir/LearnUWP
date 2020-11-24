using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeGame
{
    public class GameBoard
    {
        public BoardCell[,] Board;
        
        private IPiece _Player;
        private List<IPiece> _Enemies;

        private Func<IPiece, List<IPiece>, bool> IsWinningState;
        private Func<IPiece, List<IPiece>, bool> IsLosingState;

        public GameBoard(GameLogics gameLogics)
        {
            InitBoard(gameLogics.BoardHigth, gameLogics.BoardWith);
            SetNighbors(gameLogics.IsBoardCyclic);

            _Player = gameLogics.CreatePlayer(Board);
            _Enemies = gameLogics.CreateEnemies(Board);

            IsWinningState = gameLogics.IsWinningState;
            IsLosingState = gameLogics.IsLosingState;
        }

        private void InitBoard(int BoardHigth, int BoardWith)
        {
            Board = new BoardCell[BoardHigth, BoardWith];
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j] = new BoardCell(i, j);
                }
            }
        }

        private void SetNighbors(bool IsCyclic)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (IsCyclic)
                    {
                        InitCyclic(i, j);
                    }
                    else
                    {
                        InitNonCyclic(i, j);
                    }
                }
            }
        }

        private void InitCyclic( int i, int j)
        {
            Board[i, j].Up = Board[(i - 1 + Board.GetLength(0)) % Board.GetLength(0), j];
            Board[i, j].Down = Board[(i + 1) % Board.GetLength(0), j];
            Board[i, j].Right = Board[i, (j + 1) % Board.GetLength(0)];
            Board[i, j].Left = Board[i, (j - 1 + Board.GetLength(1)) % Board.GetLength(1)];
        }

        private void InitNonCyclic( int i, int j)
        {
            Board[i, j].Up = Board[i == 0 ? 0 : i - 1, j];
            Board[i, j].Down = Board[i == Board.GetLength(0) - 1 ? Board.GetLength(0) - 1 : i + 1, j];
            Board[i, j].Right = Board[i, j == Board.GetLength(1) - 1 ? Board.GetLength(1) - 1 : (j + 1)];
            Board[i, j].Left = Board[i, j == 0 ? 0 : j - 1];
        }

        public int[,] GetState()
        {
            int[,] state = new int[Board.GetLength(0), Board.GetLength(1)];
            state[_Player.Height, _Player.Width] = _Player.ID;
            foreach( var enemy in _Enemies)
            {
                state[enemy.Height, enemy.Width] = enemy.ID;
            }

            return state;
        }

        public GameStatus GetGameStatus()
        {
            if (IsWinningState(_Player, _Enemies))
            {
                return GameStatus.Win;
            }

            if (IsLosingState(_Player, _Enemies))
            {
                return GameStatus.Lose;
            }

            return GameStatus.Playing;
        }

        public void Update(Direction playersDirection)
        {
            _Player.Update(_Player, playersDirection);
            foreach(var enemy in _Enemies)
            {
                enemy.Update(_Player, playersDirection);
            }
        }
    }
}

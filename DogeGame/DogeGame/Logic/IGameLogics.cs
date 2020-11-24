using System;
using System.Collections.Generic;

namespace DogeGame
{
    public class GameLogics
    {
        public int BoardHigth { get;  set; }
        public int BoardWith { get;  set; }
        public bool IsBoardCyclic { get;  set; }

        internal IPiece CreatePlayer(BoardCell[,] board)
        {
            throw new NotImplementedException();
        }

        internal List<IPiece> CreateEnemies(BoardCell[,] board)
        {
            throw new NotImplementedException();
        }

        internal bool IsWinningState(IPiece player, List<IPiece> enemies)
        {
            return enemies.Count < 2;
        }

        internal bool IsLosingState(IPiece player, List<IPiece> enemies)
        {
            foreach(var enemy in enemies)
            {
                if (enemy.Height == player.Height && enemy.Width == player.Width)
                    return true;
            }
            return false;
        }
    }
}
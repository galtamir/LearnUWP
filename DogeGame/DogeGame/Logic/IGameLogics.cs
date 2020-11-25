using DogeGameLogics.Logic.Pieces;
using DogeGameLogics.Logic.PositionTarsformers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DogeGameLogics.Logic
{
    public class GameLogics
    {
        public int BoardHiegth { get; init; }
        public int BoardWidth { get; init; }

        private Position _playerPosition;
        private IEnumerable<Position> _enemiesPositions;
        private IPositionTarsformer _positionTarsformer;

        internal GameLogics(int boardHiegth, int boardWidth, bool isBoardCyclic, 
            Position playerPosition, IEnumerable<Position> enemiesPositions)
        {
            BoardHiegth = boardHiegth;
            BoardWidth = boardWidth;
            _playerPosition = playerPosition;
            _enemiesPositions = enemiesPositions;
            _positionTarsformer = isBoardCyclic 
                ? new CyclicTarsformer(BoardHiegth, BoardWidth) 
                : new NonCyclicTarsformer(BoardHiegth, BoardWidth);
        }

        public Piece CreatePlayer()
        {
            return new Player(-1, _playerPosition, _positionTarsformer);
        }

        public ICollection<Piece> CreateEnemies()
        {
            var l = new List<Piece>();
            var id = 1;
            foreach(var pos in _enemiesPositions)
            {
                l.Add(new Enemy(id++, pos, _positionTarsformer));
            }
            return l;
        }

        public static LogicsBuilder LogicsBuilder()
        {
            return new LogicsBuilder();
        }



        public bool IsWinningState(Piece player, ICollection<Piece> enemies)
        {
            return enemies.Count < 2;
        }

        public bool IsLosingState(Piece player, ICollection<Piece> enemies)
        {
            foreach(var enemy in enemies)
            {
                if (enemy.Position == player.Position)
                    return true;
            }
            return false;
        }

        public void Validate(Piece player, ICollection<Piece> enemies)
        {
            var duplicats = enemies.GroupBy(x => x.Position)
                  .Where(g => g.Count() > 1).Select(x => x.GetEnumerator())
                  .ToList();

            foreach (var d in duplicats)
            {
                d.MoveNext();
                while (d.MoveNext())
                {
                    enemies.Remove(d.Current);
                }
            }
        }
    }
}
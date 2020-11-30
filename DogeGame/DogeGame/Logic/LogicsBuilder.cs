using System;
using System.Collections.Generic;
using System.Linq;

namespace DodgeGameLogics.Logic
{
    public class LogicsBuilder
    {

        private int _heigth = 100;
        private int _width = 100;

        private bool _isCyclic = false;

        private int _numberOfEnemies = 10;

        private Position? playerPosition = null;

        private IEnumerable<Position> enemyPositions = null;

        public LogicsBuilder()
        {
            
        }

        public GameLogics FromSate(State State)
        {
            return new GameLogics(State.BoardHeigth, State.BoardWidth, State.IsBoardCyclic, State.PlayerPosition, State.EnemyPositions);
        }
        public GameLogics BuildLogics()
        {
            if(playerPosition == null)
            {
                playerPosition = new Position { Height = _heigth/2, Width = _width/2};
            }

            if (enemyPositions == null)
            {
                enemyPositions = TraversBoarder().Take(_numberOfEnemies);
            }

            return new GameLogics(_heigth, _width, _isCyclic, playerPosition.Value, enemyPositions);
        }

        public LogicsBuilder SetHeigth(int heigth)
        {
            _heigth = heigth;
            return this;
        }

        public LogicsBuilder Cyclic(bool isCyclic)
        {
            _isCyclic = isCyclic;
            return this;
        }

        public LogicsBuilder SetWidth(int width)
        {
            _width = width;
            return this;
        }

        public LogicsBuilder NumberOfEnemies(int v)
        {
            _numberOfEnemies = v;
            return this;
        }

        private IEnumerable<Position> TraversBoarder()
        {
            int delta = (int)Math.Max((_heigth + _width) * 2.0 / _numberOfEnemies, 3);
            Position p = new Position { Height = 0, Width = 0 };
            yield return p;
            while (p.Width + delta < _width)
            {
                p = new Position {Height = 0, Width = p.Width + delta };
                yield return p;
            }

            while (p.Height + delta < _heigth)
            {
                p = new Position { Height = p.Height  + delta, Width = _width-1 };
                yield return p;
            }

            while (p.Width - delta >= 0)
            {
                p = new Position { Height = _heigth -1, Width = p.Width - delta };
                yield return p;
            }

            while (p.Height - delta > 0)
            {
                p = new Position { Height = p.Height - delta, Width = 0 };
                yield return p;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace DogeGameLogics.Logic
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

        public GameLogics Build()
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

        public LogicsBuilder Cyclic()
        {
            _isCyclic = true;
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
            Position p = new Position { Height = 0, Width = 0 };
            yield return p;
            while (p.Width + 3 < _width)
            {
                p = new Position {Height = 0, Width = p.Width + 3 };
                yield return p;
            }

            while (p.Height + 3 < _heigth)
            {
                p = new Position { Height = p.Height  + 3 , Width = _width-1 };
                yield return p;
            }

            while (p.Width - 3 >= 0)
            {
                p = new Position { Height = _heigth -1, Width = p.Width -3 };
                yield return p;
            }

            while (p.Height - 3 > 0)
            {
                p = new Position { Height = p.Height - 3, Width = 0 };
                yield return p;
            }
        }
    }
}
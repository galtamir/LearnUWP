using System;
using System.Collections.Generic;
using System.Linq;

namespace DogeGameLogics.Logic
{
    public class GameLogics
    {
        public int BoardHiegth { get;  set; }
        public int BoardWidth { get;  set; }
        
        public bool IsBoardCyclic { get;  set; }

        internal Piece CreatePlayer()
        {
            throw new NotImplementedException();
        }

        internal List<Piece> CreateEnemies()
        {
            throw new NotImplementedException();
        }

        internal bool IsWinningState(Piece player, ICollection<Piece> enemies)
        {
            var duplicats = enemies.GroupBy(x => x.Position)
              .Where(g => g.Count() > 1).Select(x=>x.GetEnumerator())
              .ToList();

            foreach (var d in duplicats)
            {
                d.MoveNext();
                while (d.MoveNext())
                {
                    enemies.Remove(d.Current);
                }
            }
            return enemies.Count < 2;
        }

        internal bool IsLosingState(Piece player, ICollection<Piece> enemies)
        {
            foreach(var enemy in enemies)
            {
                if (enemy.Position == player.Position)
                    return true;
            }
            return false;
        }
    }
}
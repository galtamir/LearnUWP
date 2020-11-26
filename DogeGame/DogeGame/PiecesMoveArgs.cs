using DogeGameLogics.Logic;
using DogeGameLogics.Logic.Pieces;
using System.Collections.Generic;
using System.Linq;

namespace DogeGameLogics
{
    public class PiecesMoveArgs
    {
        public PiecesMoveArgs(Piece player, ICollection<Piece> enemies)
        {
            Positions = enemies.ToDictionary(x => x.ID, x => x.Position);
            Positions.Add(player.ID, player.Position);
        }

        public IDictionary<int, Position> Positions { get; }
    }
}
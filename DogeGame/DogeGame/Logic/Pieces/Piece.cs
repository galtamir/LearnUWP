using DogeGame;
using DogeGameLogics;
using DogeGameLogics.Logic.PositionTarsformers;

namespace DogeGameLogics.Logic.Pieces
{
    public abstract class Piece
    {
        public int ID { get; init; }

        public Position Position { get; protected set; }

        public abstract void Update(Piece player, Direction playersDirection);

        protected IPositionTarsformer PositionTarsformer;

        internal Piece(IPositionTarsformer positionTarsformer, int id, Position position)
        {
            PositionTarsformer = positionTarsformer;
            ID = id;
            Position = position;
        }
    }
}
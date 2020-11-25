using DogeGame;
using DogeGameLogics;
using DogeGameLogics.Logic.PositionTarsformers;

namespace DogeGameLogics.Logic
{
    internal abstract class Piece
    {
        public int ID { get; }

        public Position Position { get; }

        public abstract void Update(Piece player, Direction playersDirection);

        protected IPositionTarsformer PositionTarsformer;

        public Piece(IPositionTarsformer positionTarsformer)
        {
            PositionTarsformer = positionTarsformer;
        }
    }
}
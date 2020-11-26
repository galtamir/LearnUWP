using DogeGameLogics;
using DogeGameLogics.Logic.PositionTarsformers;
using System;

namespace DogeGameLogics.Logic.Pieces
{
    public abstract class Piece
    {
        public int ID { get; init; }

        public Position Position { get; protected set; }

        public abstract void Update(Piece player, Direction playersDirection);

        protected IPositionTarsformer PositionTarsformer;

        internal Piece(IPositionTarsformer positionTarsformer, int id, Position startPosition)
        {
            PositionTarsformer = positionTarsformer;
            ID = id;
            Position = startPosition;
        }
    }
}
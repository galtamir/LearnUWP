using DogeGame;
using DogeGameLogics;
using DogeGameLogics.Logic.PositionTarsformers;
using System;

namespace DogeGameLogics.Logic.Pieces
{
    public abstract class Piece
    {
        public event EventHandler<PieceMoveArgs> OnPieceMove = (a, b) => { };

        public int ID { get; init; }

        private Position _position;
        public Position Position 
        {
            get
            {
                return _position;
            } 
            protected set
            {
                OnPieceMove(ID, new PieceMoveArgs(_position, value));
                _position = value;
            }
        }

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
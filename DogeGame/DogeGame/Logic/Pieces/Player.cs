﻿using DodgeGameLogics.Logic.PositionTarsformers;

namespace DodgeGameLogics.Logic.Pieces
{
    internal class Player : Piece
    {
        public Player(int id, Position position, IPositionTarsformer positionTarsformer) : base(positionTarsformer, id, position)
        {
        }

        public override void Update(Piece player, Direction direction)
        {
            Position = PositionTarsformer.Move(Position, direction);
        }
    }
}
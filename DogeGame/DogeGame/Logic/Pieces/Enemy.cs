using DodgeGameLogics.Logic.PositionTarsformers;
using System;

namespace DodgeGameLogics.Logic.Pieces
{
    internal class Enemy : Piece
    {
        public Enemy(int id, Position pos, IPositionTarsformer positionTarsformer) : base(positionTarsformer, id, pos)
        {
        }

        public override void Update(Piece player, Direction playersDirection)
        {
            int deltaY = player.Position.Height - Position.Height;
            int deltaX = player.Position.Width - Position.Width;
            Direction direction = Direction.Stay;
            if (Math.Abs(deltaY) > Math.Abs(deltaX))
            {
                if(deltaY > 0)
                {
                    direction = Direction.Down;
                }
                else
                {
                    direction = Direction.Up;
                }
            }
            else
            {
                if (deltaX > 0)
                {
                    direction = Direction.Right;
                }
                else
                {
                    direction = Direction.Left;
                }
            }
            
            Position = PositionTarsformer.Move(Position, direction);
        }
    }
}
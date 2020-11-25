using DogeGame;
using DogeGameLogics;

namespace DogeGameLogics.Logic.PositionTarsformers
{
    public abstract class IPositionTarsformer
    {
        protected int MaxHight { get; init; }
        protected int MaxWidth { get; init; }

        protected int MaxHightCellNumber => MaxHight - 1;
        protected int MaxWidthCellNumber => MaxWidth - 1;

        public IPositionTarsformer(int maxHight, int maxWidth)
        {
            MaxHight = maxHight;
            MaxWidth = maxWidth;
        }

        public Position Move(Position from, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return Up(from);
                case Direction.Down: return Down(from);
                case Direction.Left: return Left(from);
                default: return Right(from);
            }
        }

        public abstract Position Up(Position from);
        public abstract Position Down(Position from);
        public abstract Position Left(Position from);
        public abstract Position Right(Position from);
    }
}
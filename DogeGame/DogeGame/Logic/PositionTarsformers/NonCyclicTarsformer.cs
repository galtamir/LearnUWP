using DogeGame;

namespace DogeGameLogics.Logic.PositionTarsformers
{
    public class NonCyclicTarsformer : IPositionTarsformer
    {
        public NonCyclicTarsformer(int maxHight, int maxWidth) : base(maxHight, maxWidth)
        {
        }

        public override Position Down(Position from)
        {
            return new Position
            {
                Height = from.Height == MaxHightCellNumber ? MaxHightCellNumber : from.Height + 1,
                Width = from.Width
            };
        }

        public override Position Left(Position from)
        {
            return new Position
            {
                Height = from.Height,
                Width = from.Width == 0 ? 0 : from.Width - 1
            };
        }

        public override Position Right(Position from)
        {
            return new Position
            {
                Height = from.Height,
                Width = from.Width == MaxWidthCellNumber ? MaxWidthCellNumber : from.Width + 1
            };
        }

        public override Position Up(Position from)
        {
            return new Position 
            { 
                Height = from.Height == 0 ? 0 : from.Height - 1, 
                Width = from.Width 
            };
        }
    }
}
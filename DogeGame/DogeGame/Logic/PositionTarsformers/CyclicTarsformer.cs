using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeGameLogics.Logic.PositionTarsformers
{
    public class CyclicTarsformer : IPositionTarsformer
    {
        public CyclicTarsformer(int maxHight, int maxWidth) : base(maxHight, maxWidth)
        {
        }

        public override Position Down(Position from)
        {
            return new Position
            {
                Height = from.Height == MaxHightCellNumber ? 0 : from.Height + 1,
                Width = from.Width
            };
        }

        public override Position Left(Position from)
        {
            return new Position
            {
                Height = from.Height,
                Width = from.Width == 0 ? MaxWidthCellNumber: from.Width - 1
            };
        }

        public override Position Right(Position from)
        {
            return new Position
            {
                Height = from.Height,
                Width = from.Width == MaxWidthCellNumber? 0 : from.Width + 1
            };
        }

        public override Position Up(Position from)
        {
            return new Position
            {
                Height = from.Height == 0 ? MaxHightCellNumber : from.Height - 1,
                Width = from.Width
            };
        }
    }
}

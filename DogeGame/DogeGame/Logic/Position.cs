using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeGameLogics.Logic
{
    public struct Position
    {
        public int Height { get; init; }
        public int Width { get; init; }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   Height == position.Height &&
                   Width == position.Width;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Height, Width);
        }

        public static bool operator ==(Position a, Position b)
        {
            return a.Height == b.Height && a.Width == b.Width;
        }

        public static bool operator !=(Position a, Position b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return $"({Height},{Width})";
        }
    }
}

using DodgeGameLogics.Logic;
using System;

namespace DodgeGameLogics
{
    public class PieceMoveArgs : EventArgs
    {
        public PieceMoveArgs(Position before, Position after)
        {
            Before = before;
            After = after;
        }

        public Position Before { get; }
        public Position After { get; }
    }
}
﻿using DogeGameLogics.Logic;
using System;

namespace DogeGameLogics
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
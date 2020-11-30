using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodgeGameLogics.Logic;

namespace DodgeGameLogics
{
    public class State
    {
        public Position PlayerPosition { get; set; }
        
        
        public IEnumerable<Position> EnemyPositions { get; set; }

        public int BoardHeigth { get; set; }
        public int BoardWidth { get; set; }
        public bool IsBoardCyclic { get; set; }
    }
}

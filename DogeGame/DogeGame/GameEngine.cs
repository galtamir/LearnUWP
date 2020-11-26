using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DogeGameLogics
{
    public class GameEngine
    {
        private int _refreshRate;
        private GameBoard _board;

        private bool _cancel = false;

        public Direction Direction { get; set; }

        public GameEngine(GameBoard board, int refreshRate)
        {
            _refreshRate = refreshRate;
            _board = board;
        }


        public async Task<GameStatus> StartGame(CancellationToken token = default)
        {
            while (_board.GetGameStatus() == GameStatus.Playing && !_cancel && !token.IsCancellationRequested)
            {
                await Task.Delay(_refreshRate);
                _board.Update(Direction);
            }
            return _board.GetGameStatus();
        }

        public void Cancel()
        {
            _cancel = true;
        }
    }
}

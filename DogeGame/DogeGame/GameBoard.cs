using DogeGameLogics.Logic;
using DogeGameLogics.Logic.Pieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeGameLogics
{
    public class GameBoard
    {
        public event EventHandler<PiecesMoveArgs> OnPieceMove = (a,b)=> { };

        private GameLogics _logics;
        private Piece _player;
        private ICollection<Piece> _enemies;

        public GameBoard(GameLogics gameLogics)
        {
            _logics = gameLogics;
            _player = gameLogics.CreatePlayer();
            _enemies = gameLogics.CreateEnemies();
        }

        public int[,] GetState()
        {
            int[,] state = new int[_logics.BoardHiegth, _logics.BoardWidth];
            state[_player.Position.Height, _player.Position.Width] = _player.ID;
            foreach( var enemy in _enemies)
            {
                state[enemy.Position.Height, enemy.Position.Width] = enemy.ID;
            }

            return state;
        }

        public Dictionary<int, Position> State => _enemies.Append(_player).ToDictionary(x => x.ID, x => x.Position);

        public GameStatus GetGameStatus()
        {
            if (_logics.IsWinningState(_player, _enemies))
            {
                return GameStatus.Win;
            }

            if (_logics.IsLosingState(_player, _enemies))
            {
                return GameStatus.Lose;
            }

            return GameStatus.Playing;
        }

        public State SaveGame()
        {
            return new State
            {
                BoardWidth = _logics.BoardWidth,
                BoardHeigth = _logics.BoardHiegth,
                EnemyPositions = _enemies.Select(x=>x.Position),
                IsBoardCyclic = _logics.IsBoardCyclic,
                PlayerPosition = _player.Position

            };
        }

        public void Update(Direction playersDirection)
        {
            _player.Update(_player, playersDirection);
            foreach (var enemy in _enemies)
            {
                enemy.Update(_player, playersDirection);
            }
            OnPieceMove(this, new PiecesMoveArgs(_player, _enemies));
            _logics.Validate(_player, _enemies);
        }
    }
}

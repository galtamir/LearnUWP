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
        private GameLogics Logics { get; init; }
        private Piece _player;
        private ICollection<Piece> _enemies;
        private ICollection<Piece> _obstacles;


        public GameBoard(GameLogics gameLogics)
        {
            Logics = gameLogics;
            _player = gameLogics.CreatePlayer();
            _enemies = gameLogics.CreateEnemies();
        }

        public int[,] GetState()
        {
            int[,] state = new int[Logics.BoardHiegth, Logics.BoardWidth];
            state[_player.Position.Height, _player.Position.Width] = _player.ID;
            foreach( var enemy in _enemies)
            {
                state[enemy.Position.Height, enemy.Position.Width] = enemy.ID;
            }

            return state;
        }

        public GameStatus GetGameStatus()
        {
            if (Logics.IsWinningState(_player, _enemies))
            {
                return GameStatus.Win;
            }

            if (Logics.IsLosingState(_player, _enemies))
            {
                return GameStatus.Lose;
            }

            return GameStatus.Playing;
        }

        public void Update(Direction playersDirection)
        {
            _player.Update(_player, playersDirection);
            foreach(var enemy in _enemies)
            {
                enemy.Update(_player, playersDirection);
            }

            Logics.Validate(_player, _enemies);
        }
    }
}

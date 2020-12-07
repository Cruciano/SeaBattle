using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GameLib.Builder;
using GameLib.Abs;
using GameLib.ShotState;

namespace GameLib.Imp
{
    class Game : IGame
    {
        private IPlayer _firstPlayer;
        private IPlayer _secondPlayer;
        private GamePreset _gamePreset;
        private int totalShipCells;

        public IBattlefield GetFirstField() => _firstPlayer.Battlefield;
        public IBattlefield GetSecondField() => _secondPlayer.Battlefield;

        public Game(IBattlefieldBuilder builder, GamePreset gamePreset)
        {
            _gamePreset = gamePreset;
            totalShipCells = 0;
            foreach (var (size, count) in _gamePreset.ShipsCount)
            {
                totalShipCells += size * count;
            }

            _firstPlayer = new Player() { AutoShoter = new RandomShot(_firstPlayer), DamagedCells = 0 };
            _secondPlayer = new Player() { AutoShoter = new RandomShot(_secondPlayer), DamagedCells = 0 };

            Director director = new Director(builder);

            director.Construct();
            _firstPlayer.Battlefield = builder.GetResult();

            builder.Reset();
            director.Construct();
            _secondPlayer.Battlefield = builder.GetResult();            
        }

        public bool TargetShot(Point target)
        {
            if (!_firstPlayer.TargetShot(target, _secondPlayer.Battlefield))
            {
                while (_secondPlayer.AutoShot(_firstPlayer.Battlefield))
                {
                    _firstPlayer.DamagedCells++;
                    if (IsGameFinished())
                    {
                        return false;
                    }
                }
                return false;
            }

            _secondPlayer.DamagedCells++;
            return true;
        }

        public bool RandomShot()
        {
            if (!_firstPlayer.AutoShot(_secondPlayer.Battlefield))
            {
                while (_secondPlayer.AutoShot(_firstPlayer.Battlefield))
                {
                    _firstPlayer.DamagedCells++;
                    if (IsGameFinished())
                    {
                        return false;
                    }
                }
                return false;
            }

            _secondPlayer.DamagedCells++;
            return true;
        }

        public bool IsGameFinished()
        {
            if(totalShipCells == _firstPlayer.DamagedCells ||
                totalShipCells == _secondPlayer.DamagedCells)
            {
                return true;
            }
            return false;
        }
    }
}

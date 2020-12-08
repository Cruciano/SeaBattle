using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GameLib.Builder;
using GameLib.Abs;
using GameLib.ShotState;

namespace GameLib.Imp
{
    public class Game : IGame
    {
        private IPlayer _firstPlayer;
        private IPlayer _secondPlayer;
        private int totalShipCells;

        public GamePreset GamePreset { get; }
        public IBattlefield GetFirstField() => _firstPlayer.Battlefield;
        public IBattlefield GetSecondField() => _secondPlayer.Battlefield;

        public Game(IBattlefieldBuilder builder, GamePreset gamePreset)
        {
            GamePreset = gamePreset;
            totalShipCells = 0;
            foreach (var (size, count) in GamePreset.ShipsCount)
            {
                totalShipCells += size * count;
            }

            _firstPlayer = new Player() { DamagedCells = 0 };
            _firstPlayer.AutoShoter = new RandomShot(_firstPlayer);

            _secondPlayer = new Player() { DamagedCells = 0 };
            _secondPlayer.AutoShoter = new RandomShot(_secondPlayer);

            Director director = new Director(builder);

            director.Construct();
            _firstPlayer.Battlefield = builder.GetResult();

            builder.Reset();
            director.Construct();
            _secondPlayer.Battlefield = builder.GetResult();            
        }

        public bool TargetShot(int x, int y)
        {
            Point target = new Point(x, y);
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
            if(totalShipCells <= _firstPlayer.DamagedCells ||
                totalShipCells <= _secondPlayer.DamagedCells)
            {
                return true;
            }
            return false;
        }
    }
}

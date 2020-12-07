using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Builder;
using GameLib.Abs;
using System.Drawing;

namespace GameLib.Imp
{
    class Game : IGame
    {
        private IPlayer _firstPlayer;
        private IPlayer _secondPlayer;
        private GamePreset _gamePreset;

        public IBattlefield GetFirstField() => _firstPlayer.Battlefield;
        public IBattlefield GetSecondField() => _secondPlayer.Battlefield;

        public Game(IBattlefieldBuilder builder, GamePreset gamePreset)
        {
            _firstPlayer = new Player() { IsTurn = true };
            _secondPlayer = new Player() { IsTurn = false };
            _gamePreset = gamePreset;

            Director director = new Director(builder);

            director.Construct();
            _firstPlayer.Battlefield = builder.GetResult();

            builder.Reset();
            director.Construct();
            _secondPlayer.Battlefield = builder.GetResult();            
        }

        public void TargetShot(Point target)
        {

        }

        public void RandomShot()
        {

        }

    }
}

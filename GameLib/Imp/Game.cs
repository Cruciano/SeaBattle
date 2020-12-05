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

        public IBattlefield GetFirstField() => _firstPlayer.Battlefield;
        public IBattlefield GetSecondField() => _secondPlayer.Battlefield;

        public Game(GamePreset preset)
        {
            _firstPlayer = new Player() { IsTurn = true };
            _secondPlayer = new Player() { IsTurn = false };

            IBattlefieldBuilder builder = new BattlefieldBuilder(preset);
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

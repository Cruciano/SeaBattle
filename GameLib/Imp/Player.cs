using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GameLib.Abs;
using GameLib.ShotState;

namespace GameLib.Imp
{
    class Player : IPlayer
    {
        public IBattlefield Battlefield { get; set; }
        public bool IsTurn { get; set; }
        public AutoShot Shot { get; set; } 

        public bool TargetShot()
        {
            return true;
        }

        public bool RandomShot()
        {
            return true;
        }
    }
}

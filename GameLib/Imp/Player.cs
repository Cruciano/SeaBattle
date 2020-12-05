using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Abs;

namespace GameLib.Imp
{
    class Player : IPlayer
    {
        public IBattlefield Battlefield { get; set; }
        public bool IsTurn { get; set; }
    }
}

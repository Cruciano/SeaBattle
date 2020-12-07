using System;
using System.Collections.Generic;
using System.Text;
using GameLib.ShotState;


namespace GameLib.Abs
{
    public interface IPlayer
    {
        IBattlefield Battlefield { get; set; }
        bool IsTurn { get; set; }
        AutoShot Shot { get; set; }
        bool TargetShot();
        bool RandomShot();
    }
}

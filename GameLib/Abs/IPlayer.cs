using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GameLib.ShotState;


namespace GameLib.Abs
{
    public interface IPlayer
    {
        IBattlefield Battlefield { get; set; }
        AutoShot AutoShoter { get; set; }
        int DamagedCells { get; set; }
        bool TargetShot(Point target, IBattlefield battlefield);
        bool AutoShot(IBattlefield battlefield);
    }
}

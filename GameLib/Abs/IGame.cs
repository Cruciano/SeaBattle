using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GameLib.Imp;

namespace GameLib.Abs
{
    public interface IGame
    {
        IBattlefield GetFirstField();
        IBattlefield GetSecondField();
        GamePreset gamePreset { get; }

        bool TargetShot(int x, int y);
        bool RandomShot();
        bool IsGameFinished();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GameLib.Abs
{
    public interface IGame
    {
        IBattlefield GetFirstField();
        IBattlefield GetSecondField();

        bool TargetShot(Point target);
        bool RandomShot();
    }
}

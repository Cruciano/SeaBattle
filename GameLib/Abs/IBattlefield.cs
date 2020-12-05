using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GameLib.Imp;

namespace GameLib.Abs
{
    public interface IBattlefield
    {
        int Size { get; }
        void SetCell(Cell cell);
        Cell GetCell(Point point);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GameLib.Builder
{
    public static class Randomizer
    {
        public static bool RandBool()
        {
            return new Random().NextDouble() > 0.5;
        }

        public static Point RandPoint(int range)
        {
            return new Point(new Random().Next(range),
                             new Random().Next(range));
        }
    }
}

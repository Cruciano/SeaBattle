using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Imp
{
    public class GamePreset
    {
        //first int - size, second - count
        public Dictionary<int, int> ShipsCount { get; set; }
        public int Size { get; set; }
    }
}

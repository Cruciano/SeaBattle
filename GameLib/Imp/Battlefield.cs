using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Imp
{
    class Battlefield
    {
        private Cell[,] _battleField;
        private int Size;

        public Battlefield(int size)
        {
            _battleField = new Cell[size, size];
            Size = size;
        }
    }
}

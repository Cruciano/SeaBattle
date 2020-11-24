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

        public void SetCell(Cell cell)
        {
            if (IsCellInField(cell))
            {
                _battleField[cell.X, cell.Y] = cell;
            }
        }

        public Cell GetCell(int x, int y)
        {
            return _battleField[x, y];
        }

        private bool IsCellInField(Cell cell)
        {
            return (cell.X < Size) && (cell.Y < Size) && (cell.X >= 0) && (cell.Y >= 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GameLib.Abs;

namespace GameLib.Imp
{
    class Battlefield : IBattlefield
    {
        private Cell[,] _battleField;
        private int _size;

        public Battlefield(int size)
        {
            _battleField = new Cell[size, size];
            _size = size;
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public void SetCell(Cell cell)
        {
            if (IsPointInField(cell.coordinates))
            {
                _battleField[cell.coordinates.X, cell.coordinates.Y] = cell;
            }
        }

        public Cell GetCell(Point point)
        {
            return _battleField[point.X, point.Y];
        }

        public bool IsPointInField(Point point)
        {
            return (point.X < _size) && (point.Y < _size) && (point.X >= 0) && (point.Y >= 0);
        }
    }
}

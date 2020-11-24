using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GameLib.Imp;

namespace GameLib.Builder
{
    class BattlefieldBuilder
    {
        private Battlefield _battlefield;
        private GamePreset _preset;

        public BattlefieldBuilder(GamePreset preset)
        {
            _preset = preset;
        }

        public void CreateBattlefield()
        {
            int size = _preset.Size;
            _battlefield = new Battlefield(size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Point point = new Point(i, j);
                    _battlefield.SetCell(new Cell { coordinates = point,
                                                    Type = CellType.empty });
                }
            }
        }

        public void CreateShips()
        {
            foreach (var (size, count) in _preset.ShipsCount)
            {
                for (int i = 0; i < count; i++)
                {
                    PlaceShipRandom(size);
                }
            }
        }

        private void PlaceShipRandom(int shipSize)
        {
            bool isHorizontal;
            Point start;

            do
            {
                isHorizontal = Randomizer.RandBool();
                start = Randomizer.RandPoint(_battlefield.Size);
            }
            while (!isShipFit(shipSize, start, isHorizontal));

            List<Cell> ship = GetCellsInRange(shipSize, start, isHorizontal);
            PutShip(ship);

            List<Cell> surroundCells = GetSurroundCells(shipSize, start, isHorizontal);
            SurroundShip(surroundCells);
        }
        
        private bool isShipFit(int size, Point start, bool isHorizontal)
        {
            List<Cell> cells = new List<Cell>();
            if (isHorizontal)
            {
                if(start.X + size <= _battlefield.Size)
                {
                    cells = GetCellsInRange(size, start, isHorizontal);
                }
            }
            else
            {
                if (start.Y + size <= _battlefield.Size)
                {
                    cells = GetCellsInRange(size, start, isHorizontal);
                }
            }

            foreach(var c in cells)
            {
                if(c.Type != CellType.empty)
                {
                    return false;
                }
            }

            return true;
        }

        private List<Cell> GetCellsInRange(int range, Point start, bool isHorizontal)
        {
            List<Cell> cells = new List<Cell>();
            
            for(int i = 0; i < range; i++)
            {
                if (isHorizontal)
                {
                    cells.Add(_battlefield.GetCell(new Point(start.X + i, start.Y)));
                }
                else
                {
                    cells.Add(_battlefield.GetCell(new Point(start.X, start.Y + i)));
                }
            }

            return cells;
        }

        private List<Cell> GetSurroundCells(int range, Point start, bool isHorizontal)
        {
            List<Cell> surroundingCells = new List<Cell>();

            if (isHorizontal)
            {
                for (int i = start.X - 1; i < start.X + range + 1; i++)
                {
                    surroundingCells.Add(new Cell { coordinates = new Point(i, start.Y + 1),
                                                        Type = CellType.nearShip });
                    surroundingCells.Add(new Cell { coordinates = new Point(i, start.Y - 1),
                                                        Type = CellType.nearShip });
                }

                surroundingCells.Add(new Cell { coordinates = new Point(start.X - 1, start.Y),
                                                        Type = CellType.nearShip });
                surroundingCells.Add(new Cell { coordinates = new Point(start.X + range + 1, start.Y),
                                                        Type = CellType.nearShip });
            }
            else
            {
                for (int i = start.Y - 1; i < start.Y + range + 1; i++)
                {
                    surroundingCells.Add(new Cell { coordinates = new Point(start.X + 1, i),
                                                        Type = CellType.nearShip });
                    surroundingCells.Add(new Cell { coordinates = new Point(start.X - 1, i),
                                                        Type = CellType.nearShip });
                }

                surroundingCells.Add(new Cell { coordinates = new Point(start.X, start.Y - 1),
                                                         Type = CellType.nearShip });
                surroundingCells.Add(new Cell { coordinates = new Point(start.X, start.Y + range + 1),
                                                         Type = CellType.nearShip });
            }

            return surroundingCells;
        }

        private void PutShip(IEnumerable<Cell> cells)
        {
            foreach(var c in cells)
            {
                c.Type = CellType.ship;
                _battlefield.SetCell(c);
            }
        }

        private void SurroundShip(IEnumerable<Cell> cells)
        {
            foreach (var c in cells)
            {
                c.Type = CellType.nearShip;
                _battlefield.SetCell(c);
            }
        }
    }
}

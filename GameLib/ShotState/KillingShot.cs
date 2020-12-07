using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GameLib.Abs;
using GameLib.Imp;

namespace GameLib.ShotState
{
    class KillingShot : AutoShot
    {
        public KillingShot(IPlayer player) : base(player)
        {
        }

        public override bool Shoot(IBattlefield battlefield)
        {
            if (IsUnfinishedShip(battlefield))
            {
                for (int x = 0; x < battlefield.Size; x++)
                {
                    for (int y = 0; y < battlefield.Size; y++)
                    {
                        Cell theoryTarget = battlefield.GetCell(new Point(x, y));

                        if (theoryTarget.Type == CellType.checkShip && IsAroundShootable(theoryTarget, battlefield))
                        {
                            KillShoot(theoryTarget, battlefield);
                            return true;
                        }
                    }
                }
            }

            ResetState();
            return true;
        }

        private bool IsUnfinishedShip(IBattlefield battlefield)
        {
            for (int x = 0; x < battlefield.Size; x++)
            {
                for (int y = 0; y < battlefield.Size; y++)
                {
                    Cell theoryTarget = battlefield.GetCell(new Point(x, y));

                    if (theoryTarget.Type == CellType.checkShip && IsAroundShootable(theoryTarget, battlefield))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsHorizontalShip(Cell cell, IBattlefield battlefield)
        {
            Point leftPoint = new Point(cell.coordinates.X+1, cell.coordinates.Y);
            Point rightPoint = new Point(cell.coordinates.X-1, cell.coordinates.Y);

            if (battlefield.IsPointInField(leftPoint))
            {
                if (battlefield.GetCell(leftPoint).Type == CellType.checkShip ||
                    battlefield.GetCell(leftPoint).Type == CellType.ship)
                {
                    return true;
                }
            }

            if (battlefield.IsPointInField(rightPoint))
            {
                if (battlefield.GetCell(rightPoint).Type == CellType.checkShip ||
                    battlefield.GetCell(rightPoint).Type == CellType.ship)
                {
                    return true;
                }
            }

            return false;
        }

        private void KillShoot(Cell start, IBattlefield battlefield)
        {
            List<Cell> ship = GetShipUnfinishedParts(start, battlefield);

            Cell targetCell = ship[Randomizer.RandInt(ship.Count)];

            battlefield.SetCell(new Cell { coordinates = targetCell.coordinates,
                                           Type = CellType.checkShip });

        }

        private List<Cell> GetShipUnfinishedParts(Cell start, IBattlefield battlefield)
        {
            List<Cell> newList = new List<Cell>();

            if(IsHorizontalShip(start, battlefield))
            {
                Cell cell = start;
                //take all right cells
                while (battlefield.IsPointInField(cell.coordinates) && 
                    (cell.Type == CellType.ship || cell.Type == CellType.checkShip))
                {
                    cell = battlefield.GetCell(new Point(cell.coordinates.X+1, cell.coordinates.Y));
                    newList.Add(cell);
                }

                cell = battlefield.GetCell(new Point(start.coordinates.X - 1, start.coordinates.Y));
                //take all left cells
                while (battlefield.IsPointInField(cell.coordinates) &&
                    (cell.Type == CellType.ship || cell.Type == CellType.checkShip))
                {
                    cell = battlefield.GetCell(new Point(cell.coordinates.X - 1, cell.coordinates.Y));
                    newList.Add(cell);
                }
            }
            else
            {
                Cell cell = start;
                //take all bottom cells
                while (battlefield.IsPointInField(cell.coordinates) &&
                    (cell.Type == CellType.ship || cell.Type == CellType.checkShip))
                {
                    cell = battlefield.GetCell(new Point(cell.coordinates.X, cell.coordinates.Y + 1));
                    newList.Add(cell);
                }

                cell = battlefield.GetCell(new Point(start.coordinates.X, start.coordinates.Y - 1));
                //take all top cells
                while (battlefield.IsPointInField(cell.coordinates) &&
                    (cell.Type == CellType.ship || cell.Type == CellType.checkShip))
                {
                    cell = battlefield.GetCell(new Point(cell.coordinates.X, cell.coordinates.Y - 1));
                    newList.Add(cell);
                }
            }

            return newList;
        }
    }
}

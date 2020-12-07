using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Imp;
using GameLib.Abs;

namespace GameLib.ShotState
{
    class NearShot : AutoShot
    {
        public NearShot(IPlayer player) : base(player)
        {
        }

        public override bool Shoot(IBattlefield battlefield)
        {
            for(int x = 0; x < battlefield.Size; x++)
            {
                for (int y = 0; y < battlefield.Size; y++)
                {
                    Cell targetNear = battlefield.GetCell(new System.Drawing.Point(x, y));

                    if (targetNear.Type == CellType.checkShip && IsAroundShootable(targetNear, battlefield))
                    {
                        return ShootNear(targetNear, battlefield);   
                    }
                }
            }

            return false;
        }

        private bool ShootNear(Cell cell, IBattlefield battlefield)
        {
            List<Cell> cellsAround = GetAroundCell(cell, battlefield);

            Cell targetCell;
            do
            {
                targetCell = cellsAround[Randomizer.RandInt(cellsAround.Count)];
            }
            while ((targetCell.Type == CellType.check) ||
                  (targetCell.Type == CellType.checkShip));

            if (targetCell.Type == CellType.ship)
            {
                battlefield.SetCell(new Cell { coordinates = targetCell.coordinates,
                                               Type = CellType.checkShip });

                if (IsAroundShootable(targetCell, battlefield))
                {
                    ChangeState(new KillingShot(_player));
                }
                return true;
            }
            else
            {
                battlefield.SetCell(new Cell { coordinates = targetCell.coordinates,
                                               Type = CellType.check });
                return false;
            }
        }
    }
}

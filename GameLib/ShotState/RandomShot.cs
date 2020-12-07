using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GameLib.Abs;
using GameLib.Imp;

namespace GameLib.ShotState
{
    class RandomShot : AutoShot
    {
        public RandomShot(IPlayer player): base(player)
        {
        }

        public override bool Shoot(IBattlefield battlefield)
        {
            Cell targetCell;
            bool isHit;

            do
            {
                targetCell = battlefield.GetCell(Randomizer.RandPoint(battlefield.Size));
            }
            while ((targetCell.Type == CellType.check) ||
                  (targetCell.Type == CellType.checkShip));


            if(targetCell.Type == CellType.ship)
            {
                battlefield.SetCell(new Cell { coordinates = targetCell.coordinates,
                                               Type = CellType.checkShip });
                isHit = true;
                if (IsAroundShootable(targetCell, battlefield))
                {
                    ChangeState(new NearShot(_player));
                }
            }
            else
            {
                battlefield.SetCell(new Cell { coordinates = targetCell.coordinates,
                                               Type = CellType.check });
                isHit = false;
            }

            return isHit;
        }
    }
}

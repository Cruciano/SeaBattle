using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GameLib.Abs;
using GameLib.ShotState;

namespace GameLib.Imp
{
    class Player : IPlayer
    {
        public IBattlefield Battlefield { get; set; }
        public AutoShot AutoShoter { get; set; }
        public int DamagedCells { get; set; }

        public bool TargetShot(Point target, IBattlefield battlefield)
        {
            if (!battlefield.IsPointInField(target))
            {
                throw new IndexOutOfRangeException($"Point {target.X}, {target.Y} is not in field");
            }

            Cell targetCell = battlefield.GetCell(target);

            if (targetCell.Type == CellType.ship)
            {
                battlefield.SetCell(new Cell { coordinates = targetCell.coordinates,
                                               Type = CellType.checkShip });
                return true;
            }

            battlefield.SetCell(new Cell { coordinates = targetCell.coordinates,
                                           Type = CellType.check });
            return false;
        }

        public bool AutoShot(IBattlefield battlefield)
        {
            return AutoShoter.Shoot(battlefield);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GameLib.Abs;
using GameLib.Imp;

namespace GameLib.ShotState
{
    public abstract class AutoShot
    {
        protected IPlayer _player;

        protected AutoShot(IPlayer player)
        {
            _player = player;
        }

        public abstract bool Shoot(IBattlefield battlefield);

        protected void ChangeState(AutoShot shot)
        {
            _player.Shot = shot;
        }

        //take point to the left, right, top and bottom
        protected List<Cell> GetAroundCell(Cell cell, IBattlefield battlefield)
        {
            List<Cell> cellsAroundCell = new List<Cell>();
            List<Point> theoryPoints = new List<Point>();

            theoryPoints.Add(new Point(cell.coordinates.X + 1, cell.coordinates.Y));
            theoryPoints.Add(new Point(cell.coordinates.X - 1, cell.coordinates.Y));
            theoryPoints.Add(new Point(cell.coordinates.X, cell.coordinates.Y + 1));
            theoryPoints.Add(new Point(cell.coordinates.X, cell.coordinates.Y - 1));

            foreach (var p in theoryPoints)
            {
                if (battlefield.IsPointInField(p))
                {
                    cellsAroundCell.Add(battlefield.GetCell(p));
                }
            }             

            return cellsAroundCell;
        }

        protected bool IsAroundShootable(Cell cell, IBattlefield battlefield)
        {
            List<Cell> newList = GetAroundCell(cell, battlefield);
            
            foreach(var c in newList)
            {
                if(c.Type == CellType.ship)
                {
                    return true;
                }
            }

            return false;
        }

        protected void ResetState()
        {
            _player.Shot = new RandomShot(_player);
        }
    }
}

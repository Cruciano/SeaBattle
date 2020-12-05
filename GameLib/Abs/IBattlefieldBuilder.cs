using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Imp;

namespace GameLib.Abs
{
    public interface IBattlefieldBuilder
    {
        public void Reset();
        public void CreateBattlefield();
        public void CreateShips();
        public IBattlefield GetResult();
    }
}

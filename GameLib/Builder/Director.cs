using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Abs;

namespace GameLib.Builder
{
    public class Director
    {
        private IBattlefieldBuilder _builder;

        public Director(IBattlefieldBuilder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.CreateBattlefield();
            _builder.CreateShips();
        }
    }
}

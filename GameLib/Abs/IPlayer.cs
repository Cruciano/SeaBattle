using System;
using System.Collections.Generic;
using System.Text;


namespace GameLib.Abs
{
    public interface IPlayer
    {
        IBattlefield Battlefield { get; set; }
        bool IsTurn { get; set; }
    }
}

using GameLib.Imp;
using System;
using System.Collections.Generic;
using System.Text;

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
                    _battlefield.SetCell(new Cell { X = i,
                                                    Y = j,
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

        }
        
    }
}

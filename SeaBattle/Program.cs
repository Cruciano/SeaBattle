using System;
using System.Collections.Generic;
using GameLib.Abs;
using GameLib.Imp;
using GameLib.Builder;

namespace SeaBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            GamePreset gamePreset = GamePresetFiller();

            IBattlefieldBuilder builder = new BattlefieldBuilder(gamePreset);
            IGame game = new Game(builder, gamePreset);

            IBattlefield firstBattlefield = game.GetFirstField();
            IBattlefield secondBattlefield = game.GetSecondField();

            View view = new View(gamePreset.Size);

            view.PrintGame(firstBattlefield, secondBattlefield);
            Console.ReadLine();
        }

        static GamePreset GamePresetFiller()
        {
            GamePreset gamePreset = new GamePreset();
            gamePreset.Size = 10;

            Dictionary<int, int> shipCounts = new Dictionary<int, int>();
            shipCounts.Add(4, 1);
            shipCounts.Add(3, 2);
            shipCounts.Add(2, 3);
            shipCounts.Add(1, 4);

            gamePreset.ShipsCount = shipCounts;
            return gamePreset;
        }
    }
}

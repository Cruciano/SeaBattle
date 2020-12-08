using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Abs;
using GameLib.Imp;

namespace SeaBattle
{
    public  class Controller
    {
        private IGame _game;
        private View _view;
        private IBattlefield firstBattlefield;
        private IBattlefield secondBattlefield;

        public Controller(IGame game)
        {
            _game = game;
            _view = new View(_game.GamePreset.Size);
        }

        public void Run()
        {
            while (!_game.IsGameFinished())
            {
                firstBattlefield = _game.GetFirstField();
                secondBattlefield = _game.GetSecondField();

                _view.Clear();

                _view.PrintGame(firstBattlefield, secondBattlefield);
                _view.PrintRequestMode();
                char mode = ReadMode();

                if (mode == 'm')
                {
                    _view.PrintRequestX();
                    int targetX = ReadInt();

                    _view.PrintRequestY();
                    int targetY = ReadInt();

                    _game.TargetShot(targetX - 1, targetY - 1);
                }
                if(mode == 'a')
                {
                    _game.RandomShot();
                }
            }


            Console.ReadLine();
        }

        private int ReadInt()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input)  || input > _game.GamePreset.Size || input < 1)
            {
                _view.PrintRequestNumber();
            }

            return input;
        }

        private char ReadMode()
        {
            string input = Console.ReadLine();
            if(input.Length != 1)
            {
                return ' ';
            }

            char inChar = input[0];
            if(inChar == 'm' || inChar == 'a')
            {
                return inChar;
            }
            return ' ';
        }
    }
}

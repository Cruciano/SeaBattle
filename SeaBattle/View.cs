using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class View
    {
        private int _size;
        private string[] _mapPlayer;
        private string[] _mapEnemy;
        private char _shipCell = '⬛';
        private char _checkedCell = '•';

        public View(int size)
        {
            _size = size+2;
            generateMaps();
        }

        public void PrintGame()
        {
            Console.Clear();
            for (int i = 0; i < _size; i++)
            {
                if (i > 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine($"  {_mapPlayer[i]}\t\t{_mapEnemy[i]}");
            }
        }

        private void generateMaps()
        {
            _mapPlayer = new string[_size];
            _mapEnemy = new string[_size];

            string topLine = "┏";
            string middleLine = "┃";
            string bottomLine = "┗";


            for (int i = 0; i < _size * 2; i++)
            {
                topLine += "━";
                bottomLine += "━";
                if (i < _size * 2)
                {
                    middleLine += " ";
                }
            }
            topLine += "┓";
            middleLine += "┃";
            bottomLine += "┛";

            _mapPlayer[0] = topLine;
            _mapEnemy[0] = topLine;
            for (int i = 1; i < _size - 1; i++)
            {
                _mapPlayer[i] = middleLine;
                _mapEnemy[i] = middleLine;
            }
            _mapPlayer[_size - 1] = bottomLine;
            _mapEnemy[_size - 1] = bottomLine;
        }
    }
}

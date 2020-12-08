using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Abs;
using GameLib.Imp;

namespace SeaBattle
{
    class View
    {
        private string[] _fieldFirst;
        private string[] _fieldSecond;
        private char _shipCell = 'S';
        private char _checkedCell = 'o';
        private char _damagedShip = 'D';

        public View(int size)
        {
            generateMaps(size + 2);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void PrintGame(IBattlefield firstField, IBattlefield secondField)
        {
            UpdateMaps(firstField, secondField);
            Console.Clear();
            for (int i = 0; i < _fieldFirst.Length; i++)
            {
                Console.WriteLine($"\t\t{_fieldFirst[i]}\t\t{_fieldSecond[i]}");
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void PrintRequestMode()
        {
            Console.WriteLine("Select the shot mode:");
            Console.WriteLine("Manual shot: m");
            Console.WriteLine("Auto shot: a");
            Console.Write(">");
        }

        public void PrintRequestX()
        {
            Console.WriteLine("Enter target coordinate X");
            Console.Write(">");
        }

        public void PrintRequestY()
        {
            Console.WriteLine("Enter target coordinate Y");
            Console.Write(">");
        }

        public void PrintRequestNumber()
        {
            Console.WriteLine("Enter a number in the field range");
            Console.Write(">");
        }

        private void generateMaps(int size)
        {
            _fieldFirst = new string[size];
            _fieldSecond = new string[size];

            string topLine = "┏";
            string middleLine = "┃";
            string bottomLine = "┗";


            for (int i = 0; i < size-2; i++)
            {
                topLine += "━";
                bottomLine += "━";
                middleLine += " ";
            }

            topLine += "┓";
            middleLine += "┃";
            bottomLine += "┛";

            _fieldFirst[0] = topLine;
            _fieldSecond[0] = topLine;
            for (int i = 1; i < size - 1; i++)
            {
                _fieldFirst[i] = middleLine;
                _fieldSecond[i] = middleLine;
            }
            _fieldFirst[size - 1] = bottomLine;
            _fieldSecond[size - 1] = bottomLine;
        }

        private void UpdateMaps(IBattlefield firstField, IBattlefield secondField)
        {
            for(int y = 0; y < firstField.Size; y++)
            {
                string firstLine = "┃";
                string secondLine = "┃";

                for (int x = 0; x < firstField.Size; x++)
                {
                    Cell firstCell = firstField.GetCell(new System.Drawing.Point(x, y));

                    switch (firstCell.Type)
                    {
                        case CellType.check:
                            firstLine += _checkedCell;
                            break;
                        case CellType.ship:
                            firstLine += _shipCell;
                            break;
                        case CellType.checkShip:
                            firstLine += _damagedShip;
                            break;
                        default:
                            firstLine += "-";
                            break;
                    }

                    Cell secondCell = secondField.GetCell(new System.Drawing.Point(x, y));

                    switch (secondCell.Type)
                    {
                        case CellType.check:
                            secondLine += _checkedCell;
                            break;
                        case CellType.checkShip:
                            secondLine += _damagedShip;
                            break;
                        default:
                            secondLine += "-";
                            break;
                    }
                }

                firstLine += "┃";
                secondLine += "┃";

                _fieldFirst[y + 1] = firstLine;
                _fieldSecond[y + 1] = secondLine;
            }
        }

    }
}

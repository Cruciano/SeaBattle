using System;

namespace SeaBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            View view = new View(10);
            view.PrintGame();
            Console.ReadLine();
        }
    }
}

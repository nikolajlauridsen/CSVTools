using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CSVTools;

namespace ExampeProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Table table = new Table();
            Random rnd = new Random();

            Console.Write("Table dimensions (width,height):");
            string[] sizeString = Console.ReadLine().Split(',');
            int width = int.Parse(sizeString[0]);
            int height = int.Parse(sizeString[1]);

            Console.WriteLine("\nGenerating data...");
            for (int y = 1; y <= height; y++) {
                Console.Write($"Generating row {y} of {height}\r");
                for (int x = 1; x <= width; x++) {
                    table[x, y] = rnd.Next(1, 255);
                }
            }


            Console.Write("\nSave? (y/n)");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                Console.Write("\nPath: ");
                table.SaveToFile(Console.ReadLine());
            }
            

        }
    }
}

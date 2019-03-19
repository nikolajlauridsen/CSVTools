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
            Console.Write("Generating data.");
            Table table = new Table();
            Random rnd = new Random();

            for (int y = 1; y <= 1000; y+= 2)
            {
                for (int x = 1; x <= 1000; x++)
                {
                    table[x, y] = rnd.Next(1, 255);
                }
            }
            Console.Write("..\n");

            //
            // Console.WriteLine(table.ToString());

            Console.Write("Path: ");
            table.SaveToFile(Console.ReadLine());
        }
    }
}

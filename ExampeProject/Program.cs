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
            table[1, 1] = "1,1";
            table[2, 1] = "2,1";
            table[3, 1] = "3,1";

            table[4, 3] = "4,3";
            table[5, 3] = "5,3";
            table[6, 3] = "6,3";
            table[1, 6] = "1";
            table[2, 6] = "2";
            table[3, 6] = "3";
            table[4, 6] = "4";
            table[5, 6] = "5";
            table[6, 6] = "6";



            Console.WriteLine(table.ToString());
            Console.ReadKey();
        }
    }
}

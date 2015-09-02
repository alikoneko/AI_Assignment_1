using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World");
            Board board = new Board(5, 2, 0);
            System.Console.WriteLine(board);

            System.Console.ReadKey();
        }
    }
}

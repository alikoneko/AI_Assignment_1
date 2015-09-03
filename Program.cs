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

            Board board = new Board(8, 3, 3);

            System.Console.WriteLine(board);
            DFS dfs = new DFS();
            Stack<Board> solution = dfs.search(board);
            System.Console.WriteLine("Search Complete!");
            foreach (Board sol in solution)
            {
                System.Console.WriteLine(sol);
            }




            System.Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AI_Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World");

            //Board board = new Board(8, 2, 0);

            //System.Console.WriteLine(board);
            //DFS dfs = new DFS();
            //Stack<Board> solution = dfs.Search(board);
            //System.Console.WriteLine("Search Complete!");

            //foreach (Board sol in solution)
            //{
            //    System.Console.WriteLine(sol);
            //    System.Threading.Thread.Sleep(500);
            //}


            GameDriver game = new GameDriver();
            game.Start();



            System.Console.ReadKey();
        }
    }
}

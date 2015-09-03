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

            //Board board = new Board(6, 3, 1);

            //System.Console.WriteLine(board);
            //DFS dfs = new DFS();
            //Stack<Board> solution = dfs.search(board, new Point(4,2));
            //System.Console.WriteLine("Search Complete!");
            //foreach (Board sol in solution)
            //{
            //    System.Console.WriteLine(sol);
            //    System.Threading.Thread.Sleep(500);
            //}


            GameDriver game = new GameDriver();
            game.StartGame();



            System.Console.ReadKey();
        }
    }
}

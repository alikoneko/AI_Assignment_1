using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AI_Assignment_1
{
    class GameDriver
    {
        int size;
        Board start;
        Board finish;
        bool setup_complete = false;

        public void Setup()
        {
            System.Console.WriteLine("Please input board size");
            while(!int.TryParse(System.Console.ReadLine(), out size))
            {
                System.Console.WriteLine("That was invalid, please try again.");
            }
            start = CreateBoard(true);
            finish = CreateBoard(false);

            setup_complete = true;
        }

        private Board CreateBoard(bool initial_value)
        {
            Board board = new Board(size, initial_value);
            while (true)
            {
                System.Console.WriteLine("Current State of Board:");
                System.Console.WriteLine(board);
                System.Console.WriteLine("Enter a pair to flip, X,Y: where 0,0 is apex, and 1,0 is second row first peg, or nothing to accept");
                string input = System.Console.ReadLine();
                if (input.Length == 0)
                {
                    break;
                }

            }
            return board;
        }
        private void PrintSolution(Stack<Board> solution)
        {
            System.Console.WriteLine("SOLVED!");
            System.Console.WriteLine("Now with 1980's animation!");
            foreach (Board state in solution)
            {
                System.Console.WriteLine(state);
                System.Threading.Thread.Sleep(50);
            }
        }

    }
}

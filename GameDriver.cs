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
            System.Console.WriteLine("Please set up starting board:");
            start = CreateBoard(true);
            System.Console.WriteLine("Please set up finishing board:");
            finish = CreateBoard(false);

            setup_complete = true;

        }

        public void Run()
        {
            if (!setup_complete)
            {
                System.Console.WriteLine("game not setup");
                return;
            }
            System.Console.WriteLine("Solving...");
            GameSolver solver = new GameSolver(start, finish);
            PrintSolution(solver.Solve());
        }

        private Board CreateBoard(bool initial_value)
        {
            Board board = new Board(size, initial_value);
            while (true)
            {
                System.Console.WriteLine("Current State of Board:");
                System.Console.WriteLine(board);
                System.Console.WriteLine("Enter a pair to flip, X,Y: where 0,0 is apex,\n and 1,0 is second row first peg,\n or enter to accept");
                string input = System.Console.ReadLine();
                if (input.Length == 0)
                {
                    if (board.PegCount(!initial_value) > 0)
                    {
                        break;
                    }
                    System.Console.WriteLine("You need at least one toggled peg.");
                    continue;
                }
                string[] tokens = input.Split(", ".ToCharArray()).Select(s => s.Trim()).ToArray<string>();
                if (tokens.Length != 2)
                {
                    System.Console.WriteLine("Input is not in format X,Y");
                    continue;
                }
                try
                {
                    board.Toggle(new Point(int.Parse(tokens[0]), int.Parse(tokens[1])));
                }
                catch (InvalidPositionException e)
                {
                    System.Console.WriteLine("Position not on board");
                }
                catch (FormatException e)
                {
                    System.Console.WriteLine("Point not an integer");
                }
                catch (OverflowException e)
                {
                    System.Console.WriteLine("Input out of range");
                }
            }
            return board;
        }

        private void PrintSolution(Stack<Board> solution)
        {
            if (solution.Count == 0)
            {
                System.Console.WriteLine("Unsolvable!");
            }
            else
            {
                System.Console.WriteLine("SOLVED!");
                System.Console.WriteLine("Now with 1980's animation!");
                foreach (Board state in solution)
                {
                    System.Console.WriteLine(state);
                    System.Threading.Thread.Sleep(200);
                }
            }
        }

    }
}

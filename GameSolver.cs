using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AI_Assignment_1
{
    class GameSolver
    {
        Board start;
        Board finish;

        public GameSolver(Board start, Board finish)
        {
            this.start = start;
            this.finish = finish;
        }
        /*
        * Recursively DFS's. These are for general solutions, where the end point doesn't matter.
        */
        public Stack<Board> Solve()
        {
            Stack<Board> solution = new Stack<Board>();
            Search(start, solution);
            return solution;
        }

        private bool Search(Board board, Stack<Board> solution)
        {
            //System.Console.WriteLine(board);
            //System.Threading.Thread.Sleep(50);
            if (board.MatchState(finish))
            {
                return true;
            }
            foreach (Board move in board.NextStates())
            {
                if (Search(move, solution))
                {
                    solution.Push(move);
                    return true;
                }
            }

            return false;
        }

    }
}

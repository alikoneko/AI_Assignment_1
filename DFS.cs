using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AI_Assignment_1
{
    class DFS
    {
        /*
        * Recursively DFS's. These are for general solutions, where the end point doesn't matter.
        */
        public Stack<Board> Search(Board board)
        {
            Stack<Board> solution = new Stack<Board>();
            Search(board, solution);
            return solution;
        }

        private bool Search(Board board, Stack<Board> solution)
        {
            //System.Console.WriteLine(board);
            //System.Threading.Thread.Sleep(50);
            if (board.BoardComplete())
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

        /*
         * Now with an endpoint solution
         */

        public Stack<Board> Search(Board board, Point end)
        {
            Stack<Board> solution = new Stack<Board>();
            Search(board, solution, end);
            return solution;
        }

        private bool Search(Board board, Stack<Board> solution, Point end)
        {
            if (board.BoardComplete(end))
            {
                return true;
            }
            foreach (Board move in board.NextStates())
            {
                if (Search(move, solution, end))
                {
                    solution.Push(move);
                    return true;
                }
            }

            return false;
        }

    }
}

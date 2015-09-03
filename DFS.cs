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
        public Stack<Board> search(Board board)
        {
            Stack<Board> solution = new Stack<Board>();
            search(board, solution);
            return solution;
        }

        private bool search(Board board, Stack<Board> solution)
        {
            //System.Console.WriteLine(board);
            //System.Threading.Thread.Sleep(500);
            if (board.board_complete())
            {
                return true;
            }
            foreach (Board move in board.next_states())
            {
                if (search(move, solution))
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

        public Stack<Board> search(Board board, Point end)
        {
            Stack<Board> solution = new Stack<Board>();
            search(board, solution, end);
            return solution;
        }

        private bool search(Board board, Stack<Board> solution, Point end)
        {
            //System.Console.WriteLine(board);
            //System.Threading.Thread.Sleep(500);
            if (board.board_complete(end))
            {
                return true;
            }
            foreach (Board move in board.next_states())
            {
                if (search(move, solution, end))
                {
                    solution.Push(move);
                    return true;
                }
            }

            return false;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_1
{
    class DFS
    {
        public Stack<Board> search(Board board)
        {
            Stack<Board> solution = new Stack<Board>();
            search(board, solution);
            return solution;
        }

        private bool search(Board board, Stack<Board> solution)
        {
            if (board.board_complete())
            {
                solution.Push(board);
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

    }
}

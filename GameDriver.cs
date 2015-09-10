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
        /*
        *  I did a lot of research on this problem before jumping in. In my research, I did find that there are board sizes (n = 3i + 1) 
        *  that are not solvable for ALL possible start points on a board. These tend to be numbers that are not multiples of 3, with points
        *  x, y, such that (x + y) % 3 == 0. I decided to add a control for this in, as what's the point of searching for a solution that does
        *  not exist. See the following URL for more information. http://home.comcast.net/~gibell/pegsolitaire/tindex.html#boards
        *  This is a general overview of his research. I would like to note that in his online solver, he hardcoded in solutions, making his  
        *  infinitely faster. http://www.mathsisfun.com/games/triangle-peg-solitaire/ solutions are hard coded for each case. 
        */

        /* These are not solvable cases for ALL (x,y) start positions. The program will run in circles forever trying to solve this.
         * This particular algorithm is discussed here, https://cs.uwaterloo.ca/journals/JIS/VOL11/Bell/bell2.pdf at theorem 2.1 
        */
        private bool CheckValid(int size, int start_x, int start_y)
        {
            if ((size % 3 == 1) && (((start_x + start_y) % 3) == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
         * This is an implementation of theorem 2.2 in the same paper. This will check to see if a start to finish point is valid. 
         * There's no point in checking for a path that just does not exist, as this will likely churn away forever. 
         * If this were the era in which the Pentagon was paying for AI, I would have taken the money and ran, and not included this.
         */
        private bool CheckValid(int size, int start_x, int start_y, int finish_x, int finish_y)
        {
            if (((((size % 3 == 1) && ((start_x + start_y) % 3 != 0))
                && (start_x + start_y + finish_x + finish_y) % 3 == 0))
                || ((size % 3 != 1 && ((start_x + start_y) % 3 == (finish_x + finish_y) % 3)))) //time permitting, find a way to reduce or refactor this to something more understandable.
            {
                return true;
            }

            return false;
        }

        //this is reallllllllly dirty, but it'll do.
        public void Start()
        {

            System.Console.WriteLine("Please enter the size of the board,\nstart x position, and start position y,\nas well as end position x and y, All seperated by spaces.");
            System.Console.WriteLine("Please note that X starts at 0, and corresponds to the row,\n and y corresponds to the row.");
            System.Console.WriteLine(" So, for first element of the 2nd row,\nwould be (1,0) using my coordinate system. (0, 0) will be at the apex of the ");
            System.Console.WriteLine(" triangle. Some positions are easier to solve for than others! Now, with n = 7, there are some positions where the puzzle is just not");
            System.Console.WriteLine("solvable. I have included this bit of error checking in my solution. No point in this churning away if there's no solution.");

            Setup();

        }

        private void Setup()
        {
            int[] setup;

            char again = 'n';
            char solve_gen = ' ';
            string raw;
            string[] tokens;

            raw = Console.ReadLine();
            tokens = raw.Split(' ');
            setup = Array.ConvertAll(tokens, int.Parse);

            if (CheckValid(setup[0], setup[1], setup[2], setup[3], setup[4]) && CheckValid(setup[0], setup[1], setup[2]))
            {
                System.Console.WriteLine("Solveable!");
                Solve(setup);
            }
            else
            {
                System.Console.WriteLine("Unsolveable!");
                if (CheckValid(setup[0], setup[1], setup[2])) //if there IS a general solution, solve for it.
                {
                    System.Console.WriteLine("Solve for the general solution? y/n");
                    solve_gen = System.Console.ReadKey().KeyChar;
                    SolveGeneral(setup[0], setup[1], setup[2]);
                }
            }
            System.Console.WriteLine("Go again? y/n  or q to quit");
            again = System.Console.ReadKey().KeyChar;
            if (again == 'y')
            {
                System.Console.Clear();
                Start();
            }

        }

        private void SolveGeneral(int size, int start_x, int start_y)
        {
            System.Console.WriteLine("Solving...");
            Board board = new Board(size, start_x, start_y);
            DFS dfs = new DFS();
            PrintSolution(dfs.Search(board));
        }

        private void Solve(int[] setup)
        {
            System.Console.WriteLine("Solving...");
            Point end_point = new Point(setup[3], setup[4]);
            Board board = new Board(setup[0], setup[1], setup[2]);
            DFS dfs = new DFS();
            PrintSolution(dfs.Search(board, end_point));
        }

        private void PrintSolution(Stack<Board> solution)
        {
            System.Console.WriteLine("Now with 1980's animation!");
            foreach (Board state in solution)
            {
                System.Console.WriteLine(state);
                System.Threading.Thread.Sleep(100);
            }
        }

    }
}

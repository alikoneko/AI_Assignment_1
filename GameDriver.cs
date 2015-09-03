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
        *  infinitely faster. 
        */

        /* These are not solvable cases for ALL (x,y) start positions. The program will run in circles forever trying to solve this.
         * This particular algorithm is discussed here, https://cs.uwaterloo.ca/journals/JIS/VOL11/Bell/bell2.pdf at theorem 2.1 
        */
        private bool CheckValid(int size, int start_x, int start_y)
        {
            if (size % 3 == 1 && (start_x + start_y) % 3 == 0 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
         * This is an implementation of theorem 2.2 in the same paper. This will check to see if a start to finish point is valid. There's no point in checking 
         * for a path that just does not exist, as this will likely churn away forever. 
         */
        private bool CheckValid(int size, int start_x, int start_y, int finish_x, int finish_y)
        {
            if(((size % 3 == 1 && (start_x + start_y)%3 !=0 
                && (start_x + start_y + finish_x + finish_y) % 3 == 0)) 
                || (size % 3 != 1 && ((start_x + start_y) % 3 == (finish_x + finish_y) % 3))) //time permitting, find a way to reduce or refactor this to something more understandable.
            {
                return true;
            }

            return false;
        }

        //this is reallllllllly dirty, but it'll do.
        public void StartGame()
        {
            Point end;
            int size, start_x, start_y, end_x, end_y;

            System.Console.WriteLine("Please enter the size of the board,\nstart x position, and start position y,\nas well as end position x and y, All seperated by spaces.");
            System.Console.WriteLine("Please note that X starts at 0, and corresponds to the row,\n and y corresponds to the row.");
            System.Console.WriteLine(" So, for first element of the 2nd row,\nwould be (1,0) using my coordinate system");
            string raw = Console.ReadLine();
            string[] tokens = raw.Split(' ');

        }

    }
}

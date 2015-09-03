using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace AI_Assignment_1
{
    class Board
    {
        private List<Point> move_options = new List<Point>
        {
            new Point(1,0),
            new Point(0, -1),
            new Point(1, 1),
            new Point(-1, 0),
            new Point(0, 1),
            new Point(-1, -1),
        };

        private Dictionary<Point, bool> pegs;
        private int size;
        private Point last_move;

        public Board(int n, int start_x, int start_y)
        {
            this.size = n;
            this.pegs = ConstructTriangleBoard(n);
            this.last_move = new Point(start_x, start_y);
            this.pegs[last_move] = false;
        }

        private Board(Board source)
        {
            this.size = source.size;
            this.pegs = new Dictionary<Point, bool>();
            foreach (KeyValuePair<Point, bool> entry in source.pegs)
            {
                this.pegs.Add(entry.Key, entry.Value);
            }
        }

        private Dictionary<Point, bool> ConstructTriangleBoard(int n)
        {
            Dictionary<Point, bool> triangle_board = new Dictionary<Point, bool>();

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y <= x; y++)
                {
                    triangle_board.Add(new Point(x, y), true);

                }
            }
                return triangle_board;
        }

        public bool BoardComplete()
        {
            return pegs.Count(d => d.Value == true) == 1;
        }

        public bool BoardComplete(Point end)
        {
            return (pegs.Count(d =>d.Value == true) == 1) && (pegs[end] == true);
        }

        public List<Board> NextStates()
        {
            List<Board> states = new List<Board>();

            states.AddRange(TryStates(last_move));

            foreach (KeyValuePair<Point, bool> entry in pegs.Where(d => d.Value == false).Where(d => d.Key != last_move))
            {
                states.AddRange(TryStates(entry.Key));
            }

            return states;
        }

        private List<Board> TryStates(Point start)
        {
            List<Board> moves = new List<Board>();
            foreach (Point move in move_options)
            {
                Point move_a = new Point(start.X + move.X, start.Y + move.Y);
                Point move_b = new Point(start.X + (move.X * 2), start.Y + (move.Y * 2));
                if (pegs.ContainsKey(move_b) && pegs[move_a] && pegs[move_b]) 
                {
                    Board state = new Board(this);
                    state.pegs[start] = true;
                    state.pegs[move_a] = false;
                    state.pegs[move_b] = false;
                    state.last_move = move_b;
                    state.move_options.Remove(move);
                    state.move_options.Insert(0, move);
                    moves.Add(state);
                }
            }
            
            return moves;
        }

        /*
         *     o
         *    o o
         *   o o o
         *  o o o o
         * _ o o o o
         */
        public override string ToString()
        {
            string return_string = "";
            for (int x = 0; x < size; x++)
            {
                return_string += String.Concat(Enumerable.Repeat(" ", size - x));
                for (int y = 0; y <= x; y++)
                {
                    Point point = new Point(x, y);
                    if (pegs[point] == true)
                    {
                        return_string += "o ";
                    }
                    else
                    {
                        return_string += "_ ";
                    }
                }

                return_string += "\n";
            }

           return return_string;
        } 

    }
}

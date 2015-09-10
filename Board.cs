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

        private HashSet<Point> highlighted_pegs;

        private Dictionary<Point, bool> pegs;
        private int size;
        private Point last_move;

        public Board(int n, bool initial_value)
        {
            this.size = n;
            this.pegs = new Dictionary<Point, bool>();

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y <= x; y++)
                {
                    pegs.Add(new Point(x, y), initial_value);

                }
            }

            this.highlighted_pegs = new HashSet<Point>();
        }

        private Board(Board source)
        {
            this.size = source.size;
            this.pegs = new Dictionary<Point, bool>();
            foreach (KeyValuePair<Point, bool> entry in source.pegs)
            {
                this.pegs.Add(entry.Key, entry.Value);
            }

            this.highlighted_pegs = new HashSet<Point>();
        }

        public bool OnBoard(Point position)
        {
            return pegs.ContainsKey(position);
        }

        public bool Toggle(Point position)
        {
            if (OnBoard(position))
            {
                pegs[position] = !pegs[position];
                return pegs[position];
            }
            throw new InvalidPositionException();
        }

        public int PegCount(bool value)
        {
            return pegs.Count(d => d.Value == value);
        }

        public List<Board> NextStates()
        {
            List<Board> states = new List<Board>();
            if (last_move != null)
            {
                states.AddRange(TryStates(last_move));
            }
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
                    state.highlighted_pegs.Add(start);
                    state.pegs[move_a] = false;
                    state.highlighted_pegs.Add(move_a);
                    state.pegs[move_b] = false;
                    state.highlighted_pegs.Add(move_b);
                    state.last_move = move_b;
                    state.move_options.Remove(move);
                    state.move_options.Insert(0, move);
                    moves.Add(state);
                }
            }

            return moves;
        }

        public bool MatchState(Board board)
        {
            if (pegs.Count != board.pegs.Count)
            {
                return false;
            }

            foreach (KeyValuePair<Point, bool> entry in pegs)
            {
                if (!board.pegs.ContainsKey(entry.Key))
                {
                    return false;
                }
                if (board.pegs[entry.Key] != entry.Value)
                {
                    return false;
                }
            }

            return true;
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
                        return_string += highlighted_pegs.Contains(point) ? "* " : "o ";
                    }
                    else
                    {
                        return_string += highlighted_pegs.Contains(point) ? ". " : "_ ";
                    }
                }

                return_string += "\n";
            }

            return return_string;
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AI_Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                GameDriver game = new GameDriver();
                game.Setup();
                game.Run();
            }
        }
    }
}

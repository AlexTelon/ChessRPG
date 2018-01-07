using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRPG.Misc
{
    class Position : IEquatable<Position>
    {
        private static int WIDTH = 8;
        private static int HEIGHT = 8;

        private int _x;
        /// <summary>
        /// 0 indexed position, between 0 and 7. Trying to set other values is ignored.
        /// </summary>
        public int X {
            get => _x;
            set
            {
                if (value >= 0 && value < WIDTH)
                {
                    _x = value;   
                }
            }
        }

        private int _y;
        /// <summary>
        /// 0 indexed position, between 0 and 7. Trying to set other values is ignored.
        /// </summary>
        public int Y {
            get => _y;
            set
            {
                if (value >= 0 && value < HEIGHT)
                {
                    _y = value;
                }
            }
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Position other)
        {
            return (this.X == other.X && this.Y == other.Y);
        }


        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }

    }
}

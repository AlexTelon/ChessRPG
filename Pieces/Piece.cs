using ChessRPG.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessRPG.Misc.Globals;

namespace ChessRPG.Pieces
{
    class Piece
    {
        public string Name { get; set; }

        public Position Position { get; set; }

        public Side Side { get; set; }


        public Piece(Position position, Side side)
        {
            Position = position;
            Side = side;
        }

    }
}

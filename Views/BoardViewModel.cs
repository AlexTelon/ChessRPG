using ChessRPG.Pieces;
using ChessRPG.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessRPG.Misc.Globals;

namespace ChessRPG.Views
{
    class BoardViewModel
    {
        private Board Board = new Board();
        public IReadOnlyList<Piece> Pieces { get => Board.Pieces; }

        public BoardViewModel()
        {
            for (int i = 0; i < 64; i++)
            {
                var position = new Position(i % 8, i % 8);

                Board.AddPiece(new Piece(position: position, side: Side.White) { Name = "" + i });
            }
        }
    }
}

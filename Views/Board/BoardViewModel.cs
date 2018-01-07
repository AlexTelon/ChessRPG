using ChessRPG.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRPG.Views.Board
{
    class BoardViewModel
    {

        public List<Piece> Test { get; set; } = new List<Piece>();


        public BoardViewModel()
        {
            for (int i = 0; i < 64; i++)
            {
                Test.Add(new Piece() { Name = "" + i });
            }
        }
    }
}

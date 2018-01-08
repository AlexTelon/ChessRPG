using ChessRPG.Placeables;
using ChessRPG.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ChessRPG.Views
{
    class PieceViewModel
    {
        public string ImagePath => Piece.ImagePath;

        public Piece Piece { get; set; } = new Piece();

        public PieceViewModel()
        {

        }
    }
}

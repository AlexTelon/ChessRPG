using ChessRPG.Misc;
using ChessRPG.Placables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ChessRPG.Placeables
{
    public class Square : Placeable
    {
        public Color BackgroundColor { get; set; } = Colors.Gray;

        public BoardPosition Position { get; set; }

        public Square(Color backgroundColor, BoardPosition position)
        {
            BackgroundColor = backgroundColor;
            Position = position;
        }

        public Square()
        {

        }
    }
}

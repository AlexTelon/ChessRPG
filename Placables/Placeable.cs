using ChessRPG.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRPG.Placables
{
    interface Placeable
    {
        /// <summary>
        /// The position of a thing on the board
        /// </summary>
        BoardPosition Position { get; set; }
    }
}

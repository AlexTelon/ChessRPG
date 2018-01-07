using ChessRPG.Misc;
using ChessRPG.Placeables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessRPG.Misc.Globals;

namespace ChessRPG.Placables.Pieces
{
    static class PieceFactory
    {
        /// <summary>
        /// Creates a new piece for a given board
        /// </summary>
        /// <param name="board"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Piece CreatePiece(Board board, PieceArchetypes type)
        {
            switch (type)
            {
                case PieceArchetypes.King:
                    break;
                case PieceArchetypes.Queen:
                    var queen = new Piece();
                    var movement = new MovementBehaviour();
                    movement.Board = board;

                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            // cannot skip moving
                            if (x == 0 && y == 0) continue;

                            movement.MovementVectors.Add(new Vector(x, y));
                        }
                    }
                    queen.SetMovementBehaviour(movement);
                    return queen;
                case PieceArchetypes.Rook:
                    break;
                case PieceArchetypes.Bishop:
                    break;
                case PieceArchetypes.Knight:
                    break;
                case PieceArchetypes.Pawn:
                    break;
                default:
                    break;

            }
            return new Piece();
        }
    }
}

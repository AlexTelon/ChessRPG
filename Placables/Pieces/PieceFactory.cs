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
            var piece = new Piece();
            piece.ImagePath = type.ToString();

            var movement = new MovementBehaviour();
            movement.Board = board;

            // Set the movementbehaviour of the piece
            switch (type)
            {
                case PieceArchetypes.King:
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            // cannot skip moving
                            if (x == 0 && y == 0) continue;

                            movement.MovementVectors.Add(new Vector(x, y));
                        }
                    }

                    movement.Steps = 1;
                    break;
                case PieceArchetypes.Queen:
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            // cannot skip moving
                            if (x == 0 && y == 0) continue;

                            movement.MovementVectors.Add(new Vector(x, y));
                        }
                    }
                    movement.Steps = 9;

                    break;
                case PieceArchetypes.Rook:
                    movement.MovementVectors.Add(new Vector(1, 0));
                    movement.MovementVectors.Add(new Vector(0, 1));
                    movement.MovementVectors.Add(new Vector(-1, 0));
                    movement.MovementVectors.Add(new Vector(0, -1));

                    movement.Steps = 9;

                    break;
                case PieceArchetypes.Bishop:
                    // first diagonal
                    movement.MovementVectors.Add(new Vector(1, 1));
                    movement.MovementVectors.Add(new Vector(-1, -1));

                    // second diagonal
                    movement.MovementVectors.Add(new Vector(-1, 1));
                    movement.MovementVectors.Add(new Vector(1, -1));

                    movement.Steps = 9;
                    break;
                case PieceArchetypes.Knight:
                    movement.MovementVectors.Add(new Vector(2, 1));
                    movement.MovementVectors.Add(new Vector(2, -1));

                    movement.MovementVectors.Add(new Vector(-2, 1));
                    movement.MovementVectors.Add(new Vector(-2, -1));


                    movement.MovementVectors.Add(new Vector(-1, 2));
                    movement.MovementVectors.Add(new Vector(1, 2));

                    movement.MovementVectors.Add(new Vector(-1, -2));
                    movement.MovementVectors.Add(new Vector(1, -2));

                    movement.Steps = 1;
                    break;
                case PieceArchetypes.Pawn:

                    // special child
                    movement.MovementVectors.Add(new Vector(1, 0));
                    movement.MovementVectors.Add(new Vector(0, 1));

                    movement.Steps = 1;

                    break;
                default:
                    break;

            }

            piece.SetMovementBehaviour(movement);

            return piece;
        }
    }
}

using ChessRPG.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessRPG.Misc.Globals;

namespace ChessRPG.Misc
{
    class MovementBehaviour
    {
        public List<Vector> MovementVectors { get; set; } = new List<Vector>();

        public Board Board { get; set; } = new Board();

        /// <summary>
        /// How many steps we are allowed to move
        /// </summary>
        public int Steps { get; set; }

        /// <summary>
        /// Returns the possible positions that can be reached from the given position with this movement behaviour
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        internal List<BoardPosition> GetPossibleBoardMovement(BoardPosition position)
        {
            var possiblePositions = new List<BoardPosition>();
            Side ourSide = Board.GetPiece(position).Side;

            foreach (var vector in MovementVectors)
            {
                var currentPosition = new BoardPosition(position);
                bool blockFound = false;

                // only add empty places, if enemy piece is found add it and then stop.
                while (currentPosition.CanMove(vector) && !blockFound)
                {
                    currentPosition += vector;
                    var currentPiece = Board.GetPiece(currentPosition);

                    // if there is a blocking piece then we will not continue past this point
                    if (currentPiece == null)
                    {
                        possiblePositions.Add(new BoardPosition(currentPosition));

                    } else
                    {
                        // We hit a piece
                        blockFound = true;

                        // We found a piece here, if its not one of ours then we can go here. But we dont ever take one from the same side
                        if (!ourSide.IsSameSide(currentPiece.Side))
                        {
                            possiblePositions.Add(new BoardPosition(currentPosition));
                        }
                    }

                    

                }

            }

            return possiblePositions;
        }
    }
}

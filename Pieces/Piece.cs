using ChessRPG.Misc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessRPG.Misc.Globals;

namespace ChessRPG.Pieces
{
    [DebuggerDisplay("Position: {Position}, Side: {Side}")]
    class Piece
    {
        public string Name { get; set; }

        /// <summary>
        /// The position of the Piece
        /// </summary>
        public BoardPosition Position { get; set; }

        /// <summary>
        /// Which side the piece is on
        /// </summary>
        public Side Side { get; set; }

        private MovementBehaviour _movementBehaviour = new MovementBehaviour();
        /// <summary>
        /// Returns the possible positions the piece could move
        /// </summary>
        public List<BoardPosition> PossibleMovement { get => _movementBehaviour.GetPossibleBoardMovement(Position); }

        public Piece(BoardPosition position, Side side)
        {
            Position = position;
            Side = side;
        }

        /// <summary>
        /// Set how this piece can move
        /// </summary>
        /// <param name="movementBehaviour"></param>
        public void SetMovementBehaviour(MovementBehaviour movementBehaviour) => _movementBehaviour = movementBehaviour;

    }
}

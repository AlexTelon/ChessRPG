using ChessRPG.Misc;
using ChessRPG.Placables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessRPG.Misc.Globals;

namespace ChessRPG.Placeables
{
    [DebuggerDisplay("Position: {Position}, Side: {Side}")]
    class Piece : Placeable
    {
        public string Name { get => Position.ToString(); }

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

        public Piece()
        {

        }

        /// <summary>
        /// Set how this piece can move
        /// </summary>
        /// <param name="movementBehaviour"></param>
        public void SetMovementBehaviour(MovementBehaviour movementBehaviour) => _movementBehaviour = movementBehaviour;

    }
}

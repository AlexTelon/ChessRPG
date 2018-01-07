using ChessRPG.Placeables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRPG.Misc
{
    class Board
    {

        private List<Piece> _pieces = new List<Piece>();
        /// <summary>
        /// All pieces on the board
        /// </summary>
        public IReadOnlyList<Piece> Pieces { get; private set; }

        /// <summary>
        /// The white peices on the board
        /// </summary>
        public List<Piece> WhitePieces { get; } = new List<Piece>();

        /// <summary>
        /// The black pieces on the board
        /// </summary>
        public List<Piece> BlackPieces { get; } = new List<Piece>();

        public List<Square> Squares { get; internal set; } = new List<Square>();

        /// <summary>
        /// Add a piece to the board, if there already is a piece on the same square then remove the current piece
        /// </summary>
        /// <param name="piece"></param>
        public void AddPiece(Piece piece)
        {
            // see if there already is a piece at that position
            Piece overridenPiece = GetPiece(piece.Position);

            if (overridenPiece != null)
            {
                //this.Remove(overridenPiece);
            }

            // Add new piece
            _pieces.Add(piece);


            // Make sure that the black and white pices lists are keeps up to date
            if (piece.Side == Globals.Side.Black) BlackPieces.Add(piece);
            else WhitePieces.Add(piece);
        }

        public Piece GetPiece(BoardPosition pos) => Pieces.FirstOrDefault(p => p.Position == pos);

        public Square GetSquare(BoardPosition pos) => Squares.First(s => s.Position == pos);

        public bool IsEmpty(BoardPosition pos) => !Pieces.Any(p => p.Position == pos);


        public void Remove(Piece piece)
        {
            _pieces.Remove(piece);
            WhitePieces.Remove(piece);
            BlackPieces.Remove(piece);
        }

        public Board()
        {
            Pieces = _pieces.AsReadOnly();
        }

    }
}

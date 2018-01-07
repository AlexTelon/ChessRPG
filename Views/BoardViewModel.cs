using ChessRPG.Pieces;
using ChessRPG.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessRPG.Misc.Globals;
using System.Windows.Input;

namespace ChessRPG.Views
{
    class BoardViewModel
    {
        private Board Board = new Board();
        public IReadOnlyList<Piece> Pieces { get => Board.Pieces; }

        public Piece SelectedPiece { get; set; }

        public RelayCommand SquareClickCommand { get; set; }

        private void OnSquareClicked(object obj)
        {
            Piece piece = obj as Piece;
            SelectedPiece = piece;
        }

        public BoardViewModel()
        {
            // Init the board (for debug)
            for (int i = 0; i < 64; i++)
            {
                var position = new BoardPosition(i % 8, i % 8);

                var piece = new Piece(position: position, side: Side.White) { Name = "" + i };

                var movementBehaviour = new MovementBehaviour();
                movementBehaviour.Board = Board;
                movementBehaviour.MovementVectors.Add(new Vector(0, 1));
                movementBehaviour.MovementVectors.Add(new Vector(1, 1));
                movementBehaviour.MovementVectors.Add(new Vector(1, 0));

                piece.SetMovementBehaviour(movementBehaviour);

                Board.AddPiece(piece);
            }


            // What happens when clicking on a square
            SquareClickCommand = new RelayCommand(OnSquareClicked);
        }
    }
}

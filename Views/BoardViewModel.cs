using ChessRPG.Misc;
using ChessRPG.Placeables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessRPG.Misc.Globals;
using System.Windows.Input;
using ChessRPG.Placables;
using System.Windows.Data;
using System.Windows.Media;
using System.Collections.ObjectModel;
using ChessRPG.Placables.Pieces;

namespace ChessRPG.Views
{
    class BoardViewModel
    {
        private Board Board = new Board();

        //public IEnumerable<Placeable> AllItems => Squares.Concat(Pieces);

        public CompositeCollection _allItems = new CompositeCollection();
        /// <summary>
        /// Contains all the items on the board
        /// </summary>
        public CompositeCollection AllItems => _allItems;

        public IEnumerable<Square> Squares { get => Board.Squares; }
        public IReadOnlyList<Piece> Pieces { get => Board.Pieces; }

        public ObservableCollection<Square> HighlightedSquares { get; set; } = new ObservableCollection<Square>();

        private Piece _selectedPiece;
        public Piece SelectedPiece
        {
            get => _selectedPiece;
            set
            {
                if (value != _selectedPiece)
                {
                    _selectedPiece = value;

                    // Get all the squares that we could go to
                    HighlightedSquares.Clear();
                    
                    var newHighlights = _selectedPiece.PossibleMovement.Select(x => Board.GetSquare(x)).ToList();
                    foreach (var square in newHighlights)
                    {
                        HighlightedSquares.Add(square);
                    }

                }
            }
        }


        public RelayCommand SquareClickCommand { get; set; }

        private void OnSquareClicked(object obj)
        {
            Piece piece = obj as Piece;
            SelectedPiece = piece;
        }

        public BoardViewModel()
        {
            // Init the board (for debug)
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (y > 1 && y < 6) continue;

                    var position = new BoardPosition(x, y);

                    //var piece = new Piece(position: position, side: Side.White);

                    var piece = PieceFactory.CreatePiece(Board, PieceArchetypes.Queen);
                    piece.Position = position;
                    if (y < 2) piece.Side = Side.White;
                    else piece.Side = Side.Black;

                    Board.AddPiece(piece);
                }
            }

            // Create all the squares
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    var position = new BoardPosition(x, y);

                    var square = new Square();
                    square.Position = position;

                    if ((x + y) % 2 == 0) square.BackgroundColor = Colors.White;
                    else square.BackgroundColor = Colors.Brown;

                    Board.Squares.Add(square);
                }
            }


            // What happens when clicking on a square
            SquareClickCommand = new RelayCommand(OnSquareClicked);


            CollectionContainer squareCC = new CollectionContainer();
            squareCC.Collection = Squares;

            CollectionContainer pieceCC = new CollectionContainer();
            pieceCC.Collection = Pieces;

            _allItems.Add(squareCC);
            _allItems.Add(pieceCC);

        }
    }
}

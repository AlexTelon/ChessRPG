using ChessRPG.Placeables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessRPG.Views
{
    /// <summary>
    /// Interaction logic for PieceView.xaml
    /// </summary>
    public partial class PieceView : UserControl
    {
        public Piece Piece
        {
            get { return (Piece)GetValue(PieceProperty); }
            set { SetValue(PieceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Piece.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PieceProperty =
            DependencyProperty.Register("Piece", typeof(Piece), typeof(PieceView), new PropertyMetadata(new Piece()));



        public PieceView()
        {
            InitializeComponent();
        }
    }
}

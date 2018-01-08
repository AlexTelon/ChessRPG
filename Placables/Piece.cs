using ChessRPG.Misc;
using ChessRPG.Placables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static ChessRPG.Misc.Globals;

namespace ChessRPG.Placeables
{
    [DebuggerDisplay("Position: {Position}, Side: {Side}")]
    public class Piece : Placeable, INotifyPropertyChanged
    {
        public string Name { get => Position.ToString(); }

        private string _localImagePath = "Pawn";
        public string ImagePath
        {
            get => "../../Sprites/" + Side + _localImagePath + ".png";
            set
            {
                if (value != _localImagePath)
                {
                    _localImagePath = value;
                    OnPropertyChanged("ImagePath");
                }
            }
        }

        private BoardPosition _position;
        /// <summary>
        /// The position of the Piece
        /// </summary>
        public BoardPosition Position
        {
            get => _position;
            set
            {
                if (value != _position)
                {
                    _position = value;
                    OnPropertyChanged("Position");
                }
            }
        }

        private Side _side;
        /// <summary>
        /// Which side the piece is on
        /// </summary>
        public Side Side
        {
            get => _side;
            set
            {
                if (value != _side)
                {
                    _side = value;
                    OnPropertyChanged("Side");
                }
            }

        }
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public Piece()
        {

        }

        /// <summary>
        /// Set how this piece can move
        /// </summary>
        /// <param name="movementBehaviour"></param>
        public void SetMovementBehaviour(MovementBehaviour movementBehaviour) => _movementBehaviour = movementBehaviour;

        private void Drop(object sender, DragEventArgs e)
        {
            var source = e.Data.GetData("Source") as string;
            if (source != null)
            {
                //int newIndex = listview.Items.IndexOf((sender as Button).Content);
                //var list = listview.ItemsSource as ObservableCollection<string>;
                //list.RemoveAt(list.IndexOf(source));
                //list.Insert(newIndex, source);
            }
        }

     
        private void PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //Task.Factory.StartNew(new Action(() =>
                //{
                //    Thread.Sleep(500);
                //    App.Current.Dispatcher.BeginInvoke(new Action(() =>
                //    {
                //        if (e.LeftButton == MouseButtonState.Pressed)
                //        {
                //            var data = new DataObject();
                //            data.SetData("Source", (sender as Button).Content);
                //            DragDrop.DoDragDrop(sender as DependencyObject, data, DragDropEffects.Move);
                //            e.Handled = true;
                //        }
                //    }), null);
                //}), CancellationToken.None);
            }
        }
    }
}

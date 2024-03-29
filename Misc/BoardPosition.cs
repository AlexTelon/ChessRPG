﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRPG.Misc
{
    public class BoardPosition : IEquatable<BoardPosition>, INotifyPropertyChanged
    {
        private static int WIDTH = 8;
        private static int HEIGHT = 8;

        private int _x;
        /// <summary>
        /// 0 indexed position, between 0 and 7. Trying to set other values is ignored.
        /// </summary>
        public int X {
            get => _x;
            set
            {
                if (WithinWidthOfBoard(value) && value != _x)
                {
                    _x = value;
                    OnPropertyChanged("Y");
                }
            }
        }

        private int _y;

        /// <summary>
        /// 0 indexed position, between 0 and 7. Trying to set other values is ignored.
        /// </summary>
        public int Y {
            get => _y;
            set
            {
                if (WithinHeightOfBoard(value) && value != _y)
                {
                    _y = value;
                    OnPropertyChanged("Y");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



        public BoardPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public BoardPosition(BoardPosition position)
        {
            this.X = position.X;
            this.Y = position.Y;
        }

       

        public static bool WithinWidthOfBoard(int x)
        {
            return (x >= 0 && x < WIDTH);
        }

        public static bool WithinHeightOfBoard(int y)
        {
            return (y >= 0 && y < HEIGHT);
        }
     
        public static bool WithinBoardBounds(int x, int y)
        {
            return (WithinWidthOfBoard(x) && WithinHeightOfBoard(y));
        }

        /// <summary>
        /// Check if one can move with a vector from this position and be within the board limits
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool CanMove(Vector vector)
        {
            var x = X + vector.X;
            var y = Y + vector.Y;

            return WithinBoardBounds(x, y);
        }

        public void Move(Vector vector)
        {
            if (CanMove(vector))
            {
                this.X += vector.X;
                this.Y += vector.Y;
            }
        }


        public bool Equals(BoardPosition other)
        {
            return (this.X == other.X && this.Y == other.Y);
        }

        public override bool Equals(object other)
        {
            var o = other as BoardPosition;
            return (this.X == o.X && this.Y == o.Y);
        }

        public override int GetHashCode()
        {
            // Cantor pairing function
            return (X + Y) * (X + Y + 1) / 2 + X;
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }

        public static BoardPosition operator +(BoardPosition lhs, Vector rhs)
        {
            var position = new BoardPosition(lhs);
            position.X += rhs.X;
            position.Y += rhs.Y;

            return position;
        }

        public static BoardPosition operator -(BoardPosition lhs, Vector rhs)
        {
            var position = new BoardPosition(lhs);
            position.X -= rhs.X;
            position.Y -= rhs.Y;

            return position;
        }

        public static bool operator ==(BoardPosition lhs, BoardPosition rhs)
        {
            return (lhs?.X == rhs?.X && lhs?.Y == rhs?.Y);
        }

        public static bool operator !=(BoardPosition lhs, BoardPosition rhs)
        {
            return (lhs?.X != rhs?.X || lhs?.Y != rhs?.Y);
        }
    }
}

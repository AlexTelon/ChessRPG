namespace ChessRPG.Misc
{
    static class Globals
    {
        public enum Side
        {
            White, Black
        }

        public static bool IsSameSide(this Side a, Side b)
        {
            return (a == b);
        }


        public enum PieceArchetypes
        {
            King, Queen, Rook, Bishop, Knight, Pawn
        }


    }
}

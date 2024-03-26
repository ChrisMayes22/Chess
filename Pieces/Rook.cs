using System;
using ChessPieces;

namespace ChessPieces
{
    public class Rook : Piece
    {
        public Rook(int row, int col, string color)
            : base(row, col)
        {
            this.Character = (color == "white") ? " ♕ " : " ♛ ";
        }
    }
}

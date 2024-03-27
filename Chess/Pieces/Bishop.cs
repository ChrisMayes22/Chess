using System;
using ChessPieces;

namespace ChessPieces
{
    public class Bishop : Piece
    {
        public Bishop(int row, int col, string color)
            : base(row, col)
        {
            this.Character = (color == "white") ? " ♕ " : " ♛ ";
        }
    }
}

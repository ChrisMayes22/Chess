using System;
using ChessPieces;

namespace ChessPieces
{
    public class King : Piece
    {
        public King(int row, int col, string color)
            : base(row, col)
        {
            this.Character = (color == "white") ? " ♕ " : " ♛ ";
        }
    }
}

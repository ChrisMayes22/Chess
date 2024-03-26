using System;
using ChessPieces;

namespace ChessPieces
{
    public class Knight : Piece
    {
        public Knight(int row, int col, string color)
            : base(row, col)
        {
            this.Character = (color == "white") ? " ♕ " : " ♛ ";
        }
    }
}

using System;
using ChessPieces;

namespace ChessPieces
{
    public class Queen : Piece
    {
        public Queen(int row, int col, string color)
            : base(row, col)
        {
            this.Character = (color == "white") ? " ♕ " : " ♛ ";
        }
    }
};

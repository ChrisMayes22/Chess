using System;
using ChessPieces;

namespace ChessPieces
{
    public class King(string color, int row, int col) : Piece(color, row, col)
    {
        private string color = color;
        private string character = (color == "white") ? " ♔ " : " ♚ ";
    }
}

using System;
using ChessPieces;

namespace ChessPieces
{
    public class Bishop(string color) : Piece(color, row, col)
    {
        private string color = color;
        private string character = (color == "white") ? " ♗ " : " ♝ ";
    }
}

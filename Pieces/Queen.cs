using System;
using ChessPieces;

namespace ChessPieces
{
    public class Queen(string color) : Pieces(color)
    {
        private string color = color;
        private string character = (color == "white") ? " ♕ " : " ♛ ";
    }
};

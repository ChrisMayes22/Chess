using System;
using ChessPieces;

namespace ChessPieces
{
    public class Rooks(string color) : Pieces(color)
    {
        private string color = color;
        public string character = (color == "white") ? " ♖ " : " ♜ ";
    }
}

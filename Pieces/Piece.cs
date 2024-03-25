using System;

namespace ChessPieces
{
    public abstract class Piece
    {
        private string color;
        private int[2] position;

        public Piece(string color, int row, int col)
        {
            this.color = color;
            this.position = new int[2] { row, col };
        }

        // public abstract void Move();
        // public abstract void Capture();
    }
};

using System;
using System.Reflection.PortableExecutable;

namespace ChessPieces
{
    public abstract class Piece
    {
        private int[] position;

        public int[] Position
        {
            get { return position; }
            set { position = value; }
        }

        public string Character { get; protected set; }

        public Piece(int row, int col)
        {
            this.Position = new int[2] { row, col };
        }

        // public abstract void Move();
        // public abstract void Capture();
    }
};

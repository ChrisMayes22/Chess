using System;

class Program {
    static void Main() {
        Board.DrawBoard(8);
    }
}

class Board {
    
    /// <summary>
    /// Draws a checkerboard pattern of the specified size.
    /// </summary>
    /// <param name="size">The size of the board to draw.</param>
    public static void DrawBoard(int size) {
        string color = " □ ";
        for(int i = 0; i < size; i++) {
            for(int j = 0; j < size; j++) {
                Console.Write(color);
                color = (color == " □ ") ? " ■ " : " □ ";
            }
            color = (color == " □ ") ? " ■ " : " □ ";
            Console.WriteLine();
        }
    }
}
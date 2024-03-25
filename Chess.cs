using System;
using System.Reflection.PortableExecutable;
using ChessPieces;
using Spectre.Console;

class Program
{
    static void Main()
    {
        GameManager.ShowGameStartOptions();
    }
}

class Board
{

    //TODO: Encapsulate position within piece instances and find 
    // a more readable way to intialize the board.
    private Dictionary<string, (int, int)> Positions =
        new()
        {
            { "WhiteRook1", (0, 0) },
            { "WhiteKnight1", (0, 1) },
            { "WhiteBishop1", (0, 2) },
            { "WhiteKing", (0, 3) },
            { "WhiteBishop2", (0, 5) },
            { "WhiteKnight2", (0, 6) },
            { "WhiteRook2", (0, 7) },
            { "WhitePawn1", (1, 0) },
            { "WhitePawn2", (1, 1) },
            { "WhitePawn3", (1, 2) },
            { "WhitePawn4", (1, 3) },
            { "WhitePawn5", (1, 4) },
            { "WhitePawn6", (1, 5) },
            { "WhitePawn7", (1, 6) },
            { "WhitePawn8", (1, 7) },
            { "BlackRook1", (7, 0) },
            { "BlackKnight1", (7, 1) },
            { "BlackBishop1", (7, 2) },
            { "BlackKing", (7, 3) },
            { "BlackQueen", (7, 4) },
            { "BlackBishop2", (7, 5) },
            { "BlackKnight2", (7, 6) },
            { "BlackRook2", (7, 7) },
            { "BlackPawn1", (6, 0) },
            { "BlackPawn2", (6, 1) },
            { "BlackPawn3", (6, 2) },
            { "BlackPawn4", (6, 3) },
            { "BlackPawn5", (6, 4) },
            { "BlackPawn6", (6, 5) },
            { "BlackPawn7", (6, 6) },
            { "BlackPawn8", (6, 7) }
        };

    /// <summary>
    /// Draws a checkerboard pattern of the specified size.
    /// </summary>
    /// <param name="size">The size of the board to draw.</param>
    public void DrawBoard(int size)
    {
        string color = " □ ";
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                AnsiConsole.Write(color);
                color = (color == " □ ") ? " ■ " : " □ ";
            }
            color = (color == " □ ") ? " ■ " : " □ ";
            AnsiConsole.WriteLine();
        }
    }
}

class GameManager
{
    public static void ShowGameStartOptions()
    {
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Hello! What would you like to do?")
                .PageSize(10)
                .AddChoices(["New Game", "Exit"])
        );
        switch (selection)
        {
            case "New Game":
                AnsiConsole.WriteLine("Starting a new game...");
                break;
            case "Exit":
                Environment.Exit(0);
                break;
        }
    }

    public static void StartGame() { }
}

using System;
using System.Reflection.PortableExecutable;
using ChessPieces;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Spectre.Console;
using Spectre.Console.Rendering;

class Program
{
    static void Main()
    {
        GameManager.TakeTurn("white", new Board());
    }
}

class Board
{
    //TODO: Encapsulate position within piece instances and find
    // a more readable way to intialize the board.
    private string[][] _board =
    [
        [" 1 ", " ♜ ", " ♞ ", " ♝ ", " ♛ ", " ♚ ", " ♝ ", " ♞ ", " ♜ "],
        [" 2 ", " ♟ ", " ♟ ", " ♟ ", " ♟ ", " ♟ ", " ♟ ", " ♟ ", " ♟ "],
        [" 3 ", " □ ", " ■ ", " □ ", " ■ ", " □ ", " ■ ", " □ ", " ■ "],
        [" 4 ", " ■ ", " □ ", " ■ ", " □ ", " ■ ", " □ ", " ■ ", " □ "],
        [" 5 ", " □ ", " ■ ", " □ ", " ■ ", " □ ", " ■ ", " □ ", " ■ "],
        [" 6 ", " ■ ", " □ ", " ■ ", " □ ", " ■ ", " □ ", " ■ ", " □ "],
        [" 7 ", " ♙ ", " ♙ ", " ♙ ", " ♙ ", " ♙ ", " ♙ ", " ♙ ", " ♙ "],
        [" 8 ", " ♖ ", " ♘ ", " ♗ ", " ♕ ", " ♔ ", " ♗ ", " ♘ ", " ♖ "],
        ["   ", " A ", " B ", " C ", " D ", " E ", " F ", " G ", " H "]
    ];

    public string getPieceAtCoordinate(int row, int col)
    {
        return this._board[row][col];
    }

    /// <summary>
    /// Draws a checkerboard pattern of the specified size.
    /// </summary>
    /// <param name="size">The size of the board to draw.</param>
    public void DrawBoard()
    {
        foreach (string[] line in _board)
        {
            string row = string.Join("", line);
            AnsiConsole.WriteLine(row);
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

    public static void RunGame()
    {
        var board = new Board();
        while (true)
        {
            board.DrawBoard();
        }
    }

    public static void TakeTurn(string playerColor, Board board)
    {
        string[] allowedPieces;
        if (playerColor == "black")
        {
            allowedPieces = ["♙", "♖", "♘", "♗", "♕", "♔"];
        }
        else
        {
            allowedPieces = ["♟", "♜", "♞", "♝", "♛", "♚"];
        }

        (int, int) userMove = GetCoordinate();
    }

    private static (int, int) GetCoordinate()
    {
        var letterDictionary = new Dictionary<string, int>()
        {
            { "A", 0 },
            { "B", 1 },
            { "C", 2 },
            { "D", 3 },
            { "E", 4 },
            { "F", 5 },
            { "G", 6 },
            { "H", 7 }
        };

        bool haveResult = false;
        string userMove = "null";

        while(!haveResult){
            userMove = AnsiConsole.Prompt(
                new TextPrompt<string>(
                    "Enter the coordinate of the piece you would like to move. Use the form 'letter number' as in F3 or A2"
                )
                    .PromptStyle("green")
            ).ToUpper();
            haveResult = Validate(userMove);
        }
        

        string[] splitUserMove = userMove.ToCharArray().Select(c => c.ToString()).ToArray();

        return (letterDictionary[splitUserMove[0]], int.Parse(splitUserMove[1]));
    }

    private static bool Validate(string input)
    {
        string letters = "ABCDEFGH";
        // Check if the input is the right length
        if (input.Length != 2)
        {
            AnsiConsole.WriteLine($"Too many characters in input {input}. Please enter a valid coordinate, such as A1 or F3.");
            return false;
        }

        // Check if the first input is a letter
        if (!letters.Contains(input[0]))
        {
            AnsiConsole.WriteLine($"Invalid letter {input[0]} from {input}. Please enter a valid coordinate, such as A1 or F3.");
            return false;
        }

        // Check if the second input is a digit where 0 < digit < 9
        if (!char.IsDigit(input[1]))
        {
            AnsiConsole.WriteLine($"{input[1]} from {input} is not a digit. Please enter a valid coordinate, such as A1 or F3.");
            return false;
        }
        if (!(input[1] - '0' < 9 && input[1] - '0' > 0))
        {
            AnsiConsole.WriteLine($"{input[1]} from {input} is not in the range 1-8. Please enter a valid coordinate, such as A1 or F3.");
            return false;
        }
        return true;
    }
}

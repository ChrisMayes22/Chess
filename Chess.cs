using System;
using System.Reflection.PortableExecutable;
using ChessPieces;
using Spectre.Console;
using Spectre.Console.Rendering;

class Program
{
    static void Main()
    {
        new Board().DrawBoard();
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

        string userMove = AnsiConsole.Prompt(
            new TextPrompt<string>(
                "Enter the coordinate of the piece you would like to move. Use the form [letter][number]"
            )
                .PromptStyle("green")
                .ValidationErrorMessage(
                    "Invalid input. Please enter a valid coordinate, such as A1 or F3."
                )
                .Validate(coordinate =>
                {
                    string[] coordinates = coordinate.Split("");
                    int col = int.Parse(coordinates[1]);
                    if (coordinates.Length != 2)
                    {
                        return ValidationResult.Error(
                            "Invalid input. Please enter a valid coordinate, such as A1 or F3."
                        );
                    }
                    else if (!letterDictionary.ContainsKey(coordinates[0]))
                    {
                        return ValidationResult.Error(
                            "Invalid input. Please enter a valid coordinate, such as A1 or F3."
                        );
                    }
                    else if (0 < col && col < 9)
                    {
                        return ValidationResult.Success();
                    }
                    else
                    {
                        return ValidationResult.Error(
                            "Invalid input. Please enter a valid coordinate, such as A1 or F3."
                        );
                    }
                })
        );

        string[] splitUserMove = userMove.Split("");

        return (letterDictionary[splitUserMove[0]], int.Parse(splitUserMove[1]));
    }
}

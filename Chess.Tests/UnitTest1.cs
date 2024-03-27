using Xunit;
using Chess;
namespace Chess.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        GameManager.Validate("New Game");
    }
}
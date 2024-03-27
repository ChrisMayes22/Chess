using Xunit;
using Chess;
namespace Chess.Tests;


public class UnitTest1
{
    [Fact]
    public void TestTrue()
    {
        //Test all valid input
        string[] possibleLetters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "a", "b", "c", "d", "e", "f", "g", "h" };
        string[] possibleNumbers = new string[] { "1", "2", "3", "4", "5", "6", "7", "8" };
        foreach(string letter in possibleLetters)
        {
            foreach(string number in possibleNumbers)
            {
                Assert.True(GameManager.Validate(letter + number));
            }
        }
    }

    [Fact]
    public void TestEdgeCases()
    {
        //Test edge cases
        Assert.False(GameManager.Validate("A0"));
        Assert.False(GameManager.Validate("A9"));
        Assert.False(GameManager.Validate("W1"));
        Assert.False(GameManager.Validate(""));
        Assert.False(GameManager.Validate("AA1"));
        Assert.False(GameManager.Validate("11"));
        Assert.False(GameManager.Validate("A"));
        Assert.False(GameManager.Validate("1"));
        Assert.False(GameManager.Validate("@1"));
        Assert.False(GameManager.Validate(null));
    }
}
namespace EchoLoop.Tests;

public class UnitTest1
{
    [Fact]
    public void ParseArgs_NoCount_DefaultsToOne() =>
        Assert.Equal(("hi", 1), Repeater.ParseArgs(["hi"]));


    [Theory]
    [InlineData("hi", 0)]
    [InlineData("hi", 1)]
    [InlineData("", 5)]
    public void Repeat_LengthMatchesCount(string message, int count) =>
        Assert.Equal(count, Repeater.Repeat(message, count).Count);
}
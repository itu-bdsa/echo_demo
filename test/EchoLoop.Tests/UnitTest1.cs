namespace EchoLoop.Tests;
using FsCheck;
using FsCheck.Fluent;
using FsCheck.Xunit;

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


    // Length invariant: n copies means n elements, all equal to the input.
    [Property]
    public bool Repeat_ProducesExactlyCountCopies(NonEmptyString m, NonNegativeInt n)
    {
        var result = Repeater.Repeat(m.Get, n.Get);
        return result.Count == n.Get && result.All(x => x == m.Get);
    }

}
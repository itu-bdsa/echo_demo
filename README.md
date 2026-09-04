# echo_demo

## Move current CLI project to src/
```
mkdir src
git mv EchoLoop.CLI src/
```

## Create solution file and add the CLI project to it
```
dotnet new sln -n EchoLoop
dotnet sln add src/EchoLoop.CLI/EchoLoop.CLI.csproj
```

## Check that the CLI project builds
```
dotnet build
dotnet run --project src/EchoLoop.CLI -- "ping" 3
dotnet run --project src/EchoLoop.CLI -- "ping" abc
```

## Create test project, add it to the solution and add the CLI as a reference
```
dotnet new xunit -o test/EchoLoop.Tests -f net8.0
dotnet sln add test/EchoLoop.Tests/EchoLoop.Tests.csproj
dotnet add test/EchoLoop.Tests reference src/EchoLoop.CLI
```

## Tests
 * Add the following tests
```
    [Fact]
    public void ParseArgs_NoCount_DefaultsToOne() =>
        Assert.Equal(("hi", 1), Repeater.ParseArgs(["hi"]));


    [Theory]
    [InlineData("hi", 0)]
    [InlineData("hi", 1)]
    [InlineData("", 5)]
    public void Repeat_LengthMatchesCount(string message, int count) =>
        Assert.Equal(count, Repeater.Repeat(message, count).Count);
```
 * Run the tests `dotnet test`

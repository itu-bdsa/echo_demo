# echo_demo Part 2
## Add FsCheck as a dependency

```
dotnet add test/EchoLoop.Tests package FsCheck.Xunit
```

## Add tests

```
    // Length invariant: n copies means n elements, all equal to the input.
    [Property]
    public bool Repeat_ProducesExactlyCountCopies(NonEmptyString m, NonNegativeInt n)
    {
        var result = Repeater.Repeat(m.Get, n.Get);
        return result.Count == n.Get && result.All(x => x == m.Get);
    }

```
If necessary, also add these imports
```
using FsCheck;
using FsCheck.Fluent;
using FsCheck.Xunit;
```

## Run tests

```
dotnet test
```
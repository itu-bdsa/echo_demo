namespace EchoLoop;

public static class Repeater
{
    public static IReadOnlyList<string> Repeat(string message, int count)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (count < 0)
            throw new ArgumentOutOfRangeException(
                nameof(count), "Count must not be negative.");

        return Enumerable.Repeat(message, count).ToList();
    }

    public static (string Message, int Count) ParseArgs(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length is 0 or > 2)
            throw new ArgumentException("Usage: echoloop <message> [count]");

        if (args.Length == 1)
            return (args[0], 1);

        if (ParseCount(args[1]) is not int count)
            throw new ArgumentException($"'{args[1]}' is not a non-negative integer.");

        return (args[0], count);
    }

    private static int? ParseCount(string s) =>
        int.TryParse(s, out var n) && n >= 0 ? n : null;
}

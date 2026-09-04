using EchoLoop;

try
{
    var (message, count) = Repeater.ParseArgs(args);
    foreach (var line in Repeater.Repeat(message, count))
        Console.WriteLine(line);
    return 0;
}
catch (ArgumentException ex)
{
    Console.Error.WriteLine(ex.Message);
    return 1;
}

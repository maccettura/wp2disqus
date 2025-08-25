namespace DisqusConvert.Extensions;

internal static class CommandOptionsExtensions
{
    public static bool Validate(this CommandOptions options)
    {
        if(string.IsNullOrWhiteSpace(options.InputFilePath))
        {
            Console.WriteLine("InputFilePath (-i) is required");
            return false;
        }

        if (string.IsNullOrWhiteSpace(options.OutputFilePath))
        {
            Console.WriteLine("OutputFilePath (-o) is required");
            return false;
        }

        if (!options.ChannelId.HasValue)
        {
            Console.WriteLine("ChannelId (-c) is required");
            return false;
        }

        return true;
    }
}

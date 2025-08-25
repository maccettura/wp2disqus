using CommandLine;

namespace DisqusConvert;

internal class CommandOptions
{
    [Option('i', "input", Required = true, HelpText = "Path to input WP XML file")]
    public string InputFilePath { get; set; }

    [Option('o', "output", Required = true, HelpText = "Path to output Disqus XML file")]
    public string OutputFilePath { get; set; }

    [Option('c', "channel", Required = true, HelpText = "The channel ID to use for root Disqus thread")]
    public int? ChannelId { get; set; }
}
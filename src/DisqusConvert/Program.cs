// See https://aka.ms/new-console-template for more information

using CommandLine;
using DisqusConvert;
using DisqusConvert.Extensions;
using DisqusConvert.Services;

//
// Set the command line parameters (-o, -i and -c) in the launchSettings.json file when running from VS
// 

await Parser.Default.ParseArguments<CommandOptions>(args).WithParsedAsync(async options =>
{
    if (!options.Validate())
    {
        return;
    }

    var wpXml = await File.ReadAllTextAsync(options.InputFilePath);
    var rootWp = FromWpService.Deserialize(wpXml);
    if (rootWp == null)
    {
        Console.WriteLine("Null WP Root!");
        return;
    }

    var rootDisqus = ToDisqusService.Convert(rootWp, options.ChannelId.Value);
    var disqusXml = ToDisqusService.Serialize(rootDisqus);

    Console.WriteLine("Writing Disques output...");
    await File.WriteAllTextAsync(options.OutputFilePath, disqusXml);

    Console.WriteLine("Press enter to exit...");
    Console.ReadLine();
});
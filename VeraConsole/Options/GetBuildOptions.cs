using CommandLine;

namespace VeraConsole.Options
{
    [Verb("getbuilds", HelpText = "Record changes to the repository.")]
    public class GetBuildOptions : BaseOptions
    {
        [Option("appid", Default = false, HelpText = "Application ID")]
        public int AppId { get; set; }
    }
}

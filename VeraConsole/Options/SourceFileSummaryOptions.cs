using CommandLine;

namespace VeraConsole.Options
{
    [Verb("sourcefilesummary", HelpText = "")]
    public class SourceFileSummaryOptions : BaseOptions
    {
        [Option("buildid", Default = false, HelpText = "Application ID")]
        public string BuildIds { get; set; }
    }
}

using CommandLine;

namespace VeraConsole.Options
{
    [Verb("policysummary", HelpText = "")]
    public class PolicySummaryOptions : BaseOptions
    {
        [Option("buildid", Default = false, HelpText = "Application ID")]
        public string BuildIds { get; set; }
    }
}

using CommandLine;

namespace VeraConsole.Options
{
    [Verb("triageflaws", HelpText = "")]
    public class GetTriageFlawsOptions : BaseOptions
    {
        [Option("buildid", Default = false, HelpText = "Application ID")]
        public string BuildIds { get; set; }
    }
}

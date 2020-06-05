using CommandLine;

namespace VeraConsole.Options
{
    [Verb("getapps", HelpText = "List all apps")]
    public class GetAppsOptions : BaseOptions
    {
        [Option("namecontains", Default = "", HelpText = "Include a name pattern such as MyApp*")]
        public string NamePattern { get; set; }
    }
}

using CommandLine;

namespace VeraConsole.Options
{
    [Verb("getlatestflaws", HelpText = "")]
    public class GetLatestFlawsOptions
    {
        [Option("namecontains", Default = "", HelpText = "Include a name pattern such as MyApp*")]
        public string NamePattern { get; set; }

        [Option('o', "output", Default = "", HelpText = "Output Format")]
        public string Output { get; set; }

        [Option('f', "filename", Default = "GetLatestFlaws", HelpText = "Output Filename")]
        public string Filename { get; set; }
    }

}

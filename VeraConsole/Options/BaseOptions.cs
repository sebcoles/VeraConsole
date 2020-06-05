using CommandLine;

namespace VeraConsole.Options
{
    public class BaseOptions
    {
        [Option('o', "output", Default = "", HelpText = "Output Format")]
        public string Output { get; set; }

        [Option('f', "filename", Default = "", HelpText = "Output Filename")]
        public string Filename { get; set; }

        [Option('a', "accountId", Default = "", HelpText = "Output Filename")]
        public string AccountId { get; set; }
    }
}

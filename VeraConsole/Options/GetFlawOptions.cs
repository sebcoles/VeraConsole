using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console.Commands
{
    [Verb("getflaws", HelpText = "")]
    public class GetFlawOptions
    {
        [Option("buildid", Default = false, HelpText = "Application ID")]
        public int BuildId { get; set; }

        [Option('o', "output", Default = "", HelpText = "Output Format")]
        public string Output { get; set; }

        [Option("fixforpolicy", Default = false, HelpText = "Output Format")]
        public bool FixForPolicy { get; set; }

        [Option('f', "filename", Default = "GetFlaws", HelpText = "Output Filename")]
        public string Filename { get; set; }
    }


}

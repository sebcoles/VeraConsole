using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console.Commands
{
    [Verb("getbuilds", HelpText = "Record changes to the repository.")]
    public class GetBuildOptions
    {
        [Option("appid", Default = false, HelpText = "Application ID")]
        public int AppId { get; set; }

        [Option('o', "output", Default = "", HelpText = "Output Format")]
        public string Output { get; set; }

        [Option('f', "filename", Default = "GetBuilds", HelpText = "Output Filename")]
        public string Filename { get; set; }
    }
}

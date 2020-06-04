using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console.Commands
{
    [Verb("getapps", HelpText = "List all apps")]
    public class GetAppsOptions
    {
        [Option('o', "output", Default = "", HelpText = "Output Format")]
        public string Output { get; set; }

        [Option('f', "filename", Default = "GetApps", HelpText = "Output Filename")]
        public string Filename { get; set; }

        [Option("namecontains", Default = "", HelpText = "Include a name pattern such as MyApp*")]
        public string NamePattern { get; set; }
    }
}

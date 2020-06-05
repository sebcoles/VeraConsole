using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace VeraConsole.Options
{
    [Verb("duplicateflaws", HelpText = "")]
    public class DuplicateFlawOptions : BaseOptions
    {
        [Option("buildid", Default = false, HelpText = "Application ID")]
        public string BuildIds { get; set; }
    }
}

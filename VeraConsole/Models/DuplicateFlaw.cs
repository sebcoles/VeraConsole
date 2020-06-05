using System;
using System.Collections.Generic;
using System.Text;

namespace VeraConsole.Models
{
    public class DuplicateFlaw
    {
        public int Count { get; set; }
        public string CategoryName { get; set; }
        public string Severity { get; set; }
        public string Modules { get; set; }
        public string SourceFile { get; set; }
        public string Builds { get; internal set; }
        public string Lines { get; internal set; }
    }
}

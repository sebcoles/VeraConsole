using System;
using System.Collections.Generic;
using System.Text;

namespace VeraConsole.Models
{
    public class SourceFileSummary
    {
        public string BuildId { get; set; }
        public int Count { get; set; }
        public string Severity { get; set; }
        public string Module { get; set; }
        public string SourceFile { get; set; }
    }
}

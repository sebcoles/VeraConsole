using System;
using System.Collections.Generic;
using System.Text;
using VeracodeService.Models;

namespace VeraConsole.Models
{
    public class ScanSummary
    {
        public string BuildId { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
        public string Severity { get; set; }
    }
}

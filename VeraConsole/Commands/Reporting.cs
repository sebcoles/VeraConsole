using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using VeracodeService.Models;
using VeracodeService.Repositories;
using VeraConsole.Helpers;
using VeraConsole.Models;
using VeraConsole.Options;

namespace VeraConsole.Commands
{
    public interface IReporting
    {
        int TriageFlaws(GetTriageFlawsOptions options);
        int PolicySummary(PolicySummaryOptions options);
        int SourceFileSummary(SourceFileSummaryOptions options);
        int DuplicateFlaws(DuplicateFlawOptions options);
    }
    public class Reporting : IReporting
    {
        private readonly IVeracodeRepository _veracodeRepository;

        public Reporting(IVeracodeRepository veracodeRepository)
        {
            _veracodeRepository = veracodeRepository;
        }

        public int DuplicateFlaws(DuplicateFlawOptions options)
        {
            var flaws = new List<FlawType>();

            foreach (var buildid in options.BuildIds.Split(','))
            {
                var buildflaws = _veracodeRepository.GetFlaws(buildid);
                foreach (var flaw in buildflaws)
                    flaw.BuildId = buildid;

                flaws.AddRange(buildflaws);
            }

            var duplicates = flaws
                  .GroupBy(p => new { p.sourcefile, p.categoryname, p.severity })
                     .Select(group => new DuplicateFlaw {
                         SourceFile = group.Key.sourcefile,
                         CategoryName = group.Key.categoryname,
                         Severity = group.Key.severity,
                         Count = group.Count(),
                         Modules = string.Join(',', group.Select(x => x.module).Distinct().ToArray()),
                         Builds = $"\"\"{string.Join(',', group.Select(x => x.BuildId).Distinct().ToArray())}\"\"",
                         Lines = $"\"\"{string.Join(',', group.Select(x => x.line).Distinct().ToArray())}\"\"",
                     }).OrderByDescending(x => x.Count);

            var output = new CsvHelper().ToCsv(duplicates);

            if (options.Output.ToLower().Equals("csv"))
            {
                File.WriteAllText($"{options.Filename}.csv", output);
            }
            else
            {
                Console.WriteLine(output);
            }
            return 1;
        }

        public int PolicySummary(PolicySummaryOptions options)
        {
            var summaries = new List<ScanSummary>();
            foreach (var buildid in options.BuildIds.Split(','))
            {
                var severities = _veracodeRepository.GetSeverity(buildid);
                foreach (var severity in severities)
                {
                    var summary = severity.category.Select(c => new ScanSummary
                    {
                        Category = c.categoryname,
                        BuildId = buildid,
                        Severity = SeverityLabel(severity.level),
                        Count = c.cwe.Sum(cwe => cwe.staticflaws.Count())
                    });
                    summaries.AddRange(summary);
                }
            }

            var output = new CsvHelper().ToCsv(summaries);

            if (options.Output.ToLower().Equals("csv"))
            {
                File.WriteAllText($"{options.Filename}.csv", output);
            }
            else
            {
                Console.WriteLine(output);
            }
            return 1;
        }

        public string SeverityLabel(string number)
        {
            switch (number)
            {
                case "0":
                    return "Informational";
                case "1":
                    return "Very Low";
                case "2":
                    return "Low";
                case "3":
                    return "Medium";
                case "4":
                    return "High";
                case "5":
                    return "Very High";
                default:
                    throw new ArgumentException();
            }
        }

        public int SourceFileSummary(SourceFileSummaryOptions options)
        {
            var summaries = new List<SourceFileSummary>();
            foreach (var buildid in options.BuildIds.Split(','))
            {
                var flaws = _veracodeRepository.GetFlaws(buildid);
                var sourceFiles = flaws.Select(x => x.sourcefile).Distinct().ToArray();

                foreach(var sourceFile in sourceFiles) {
                    var filterFlaws = flaws.Where(x => x.sourcefile.Equals(sourceFile));
                    foreach(var severity in filterFlaws.Select(x => x.severity).Distinct()) {
                        var filterFlaws2 = filterFlaws.Where(x => x.severity.Equals(severity));
                        foreach (var module in filterFlaws2.Select(x => x.module).Distinct()) {
                            var filterFlaws3 = filterFlaws2.Where(x => x.module.Equals(module));

                            summaries.Add(new SourceFileSummary
                            {
                                BuildId = buildid,
                                Severity = severity,
                                Count = filterFlaws3.Count(),
                                Module = module,
                                SourceFile = sourceFile
                            });
                        }
                    }
                   
                }
            }

            var output = new CsvHelper().ToCsv(summaries);

            if (options.Output.ToLower().Equals("csv"))
            {
                File.WriteAllText($"{options.Filename}.csv", output);
            }
            else
            {
                Console.WriteLine(output);
            }
            return 1;
        }

        public int TriageFlaws(GetTriageFlawsOptions options)
        {
            var allFlaws = new List<FlawType>();
            foreach (var buildid in options.BuildIds.Split(','))
            {
                var flaws = _veracodeRepository
                    .GetFlaws(buildid)
                    .OrderBy(x => x.issueid);

                foreach (var flaw in flaws)
                    flaw.BuildId = buildid;

                allFlaws.AddRange(flaws);
            }

            var output = new CsvHelper().ToCsv(allFlaws);

            if (options.Output.ToLower().Equals("csv"))
            {
                File.WriteAllText($"{options.Filename}.csv", output);
            }
            else
            {
                Console.WriteLine(output);
            }
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using VeracodeService.Models;

namespace VeracodeService.Repositories
{
    public interface IVeracodeRepository
    {
        IEnumerable<VeracodeApp> GetAllApps();
        IEnumerable<Build> GetAllBuildsForApp(string appId);
        detailedreport GetDetailedReport(string buildId);
        string[] GetFlawIds(string buildId);
        Mitigation GetAllMitigationsForBuildAndFlaws(string buildIds, string[] flawIds);
        FlawType[] GetFlaws(string buildId);
        SeverityType[] GetSeverity(string buildId);
    }
    public class VeracodeRepository : IVeracodeRepository
    {
        private readonly IVeracodeWrapper _wrapper;
        public VeracodeRepository(IVeracodeWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public IEnumerable<VeracodeApp> GetAllApps()
        {
            var xml = _wrapper.GetAppList();

            if (string.IsNullOrWhiteSpace(xml))
                return new VeracodeApp[0];

            AppList list = XmlParseHelper.Parse<AppList>(xml);
            return list.Apps;
        }

        public IEnumerable<Build> GetAllBuildsForApp(string appId)
        {
            var xml = _wrapper.GetBuildList(appId);
            BuildList response = XmlParseHelper.Parse<BuildList>(xml);

            if (string.IsNullOrWhiteSpace(xml))
                return new Build[0];

            return response.Builds;
        }
        public Mitigation GetAllMitigationsForBuildAndFlaws(string buildIds, string[] flawIds)
        {
            var flaw_string = string.Join(",", flawIds);
            var xml = _wrapper.GetMitigationInfo(buildIds, flaw_string);

            if (string.IsNullOrWhiteSpace(xml))
                return null;

            return XmlParseHelper.Parse<Mitigation>(xml);
        }

        public detailedreport GetDetailedReport(string buildId)
        {
            var xml = _wrapper.GetDetailedResults(buildId);

            if (string.IsNullOrWhiteSpace(xml))
                return null;

            return XmlParseHelper.Parse<detailedreport>(xml);
        }

        public FlawType[] GetFlaws(string buildId)
        {
            var xml = _wrapper.GetDetailedResults(buildId);

            if (string.IsNullOrWhiteSpace(xml))
                return new FlawType[0];

            var report = XmlParseHelper.Parse<detailedreport>(xml);

            if (report.severity == null || !report.severity.Any())
                return new FlawType[0];

            return report.severity.Where(x => x.category != null && x.category.Any())
                .SelectMany(sev => sev.category.Where(x => x.cwe != null && x.cwe.Any())
                .SelectMany(cat => cat.cwe.Where(x => x.staticflaws != null && x.staticflaws.Any())
                .SelectMany(cwe => cwe.staticflaws)))
                .ToArray();
        }

        public SeverityType[] GetSeverity(string buildId)
        {
            var xml = _wrapper.GetDetailedResults(buildId);

            if (string.IsNullOrWhiteSpace(xml))
                return new SeverityType[0];

            var report = XmlParseHelper.Parse<detailedreport>(xml);
            return report.severity.ToArray();
        }

        public string[] GetFlawIds(string buildId)
        {
            var flaws = GetFlaws(buildId);
            return flaws.Select(flaw => flaw.issueid)
                .OrderBy(x => Int32.Parse(x))
                .ToArray();
        }
    }
}


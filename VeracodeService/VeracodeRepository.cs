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
        DetailedReport GetDetailedReport(string buildId);
        string[] GetFlawIds(string buildId);
        Mitigation GetAllMitigationsForBuildAndFlaws(string buildIds, string[] flawIds);
        Flaw[] GetFlaws(string buildId);
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
            AppList list = XmlParseHelper.Parse<AppList>(xml);
            return list.Apps;
        }

        public IEnumerable<Build> GetAllBuildsForApp(string appId)
        {
            var xml = _wrapper.GetBuildList(appId);
            BuildList response = XmlParseHelper.Parse<BuildList>(xml);
            return response.Builds;
        }
        public Mitigation GetAllMitigationsForBuildAndFlaws(string buildIds, string[] flawIds)
        {
            var flaw_string = string.Join(",", flawIds);
            var xml = _wrapper.GetMitigationInfo(buildIds, flaw_string);
            return XmlParseHelper.Parse<Mitigation>(xml);
        }

        public DetailedReport GetDetailedReport(string buildId)
        {
            var xml = _wrapper.GetDetailedResults(buildId);
            return XmlParseHelper.Parse<DetailedReport>(xml);
        }

        public Flaw[] GetFlaws(string buildId)
        {
            var xml = _wrapper.GetDetailedResults(buildId);
            var report = XmlParseHelper.Parse<DetailedReport>(xml);
            return report.Severity
                .SelectMany(sev => sev.Category
                .SelectMany(cat => cat.Cwe
                .SelectMany(cwe => cwe.Staticflaws.Flaw)))
                .ToArray();
        }

        public string[] GetFlawIds(string buildId)
        {
            var flaws = GetFlaws(buildId);
            return flaws.Select(flaw => flaw.Issueid)
                .OrderBy(x => Int32.Parse(x))
                .ToArray();
        }
    }
}


using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using VeracodeService;
using VeracodeService.Repositories;
using VeracodeWebhooks.Configuration;
using Console.Commands;
using System.Linq;
using VeraConsole.Options;

namespace WebhookRunner
{
    class Program
    {
        private static ServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
                .AddJsonFile($"appsettings.Development.json", false)
#else
                .AddJsonFile("appsettings.json", false)
#endif
                .Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.Configure<VeracodeConfiguration>(options => Configuration.GetSection("Veracode").Bind(options));
            serviceCollection.AddScoped<IVeracodeWrapper, VeracodeWrapper>();
            serviceCollection.AddScoped<IVeracodeRepository, VeracodeRepository>();
            _serviceProvider = serviceCollection.BuildServiceProvider();

            Parser.Default.ParseArguments<GetAppsOptions, GetBuildOptions, GetFlawOptions, GetLatestFlawsOptions>(args)
                .MapResult(
                  (GetAppsOptions opts) => GetApps(opts),
                  (GetBuildOptions opts) => GetBuilds(opts),
                  (GetFlawOptions opts) => GetFlaws(opts),
                  (GetLatestFlawsOptions opts) => GetLatestFlaws(opts),
                  errs => HandleParseError(errs));
        }

        static int GetApps(GetAppsOptions options)
        {
            var repo = _serviceProvider.GetService<IVeracodeRepository>();
            var apps = repo.GetAllApps().Where(x => x.App_name.Contains(options.NamePattern));

            if(options.NamePattern != "")
                apps = apps.Where(x => x.App_name.Contains(options.NamePattern)).ToArray();

            var output = "App_id, App_name\n";
            foreach(var app in apps)
            {
                output += $"{app.App_id},{app.App_name}\n";
            }

            if (options.Output.ToLower().Equals("csv"))
            {
                File.WriteAllText($"{options.Filename}.csv", output);
            } else
            {
                System.Console.WriteLine(output);
            }
            return 1;
        }

        static int GetBuilds(GetBuildOptions options)
        {
            var repo = _serviceProvider.GetService<IVeracodeRepository>();
            var builds = repo.GetAllBuildsForApp(""+options.AppId);
            var output = "Build_id, Launch_date, Results_ready, Submitter\n";
            foreach (var build in builds)
            {
                output += $"{build.Build_id},{build.Launch_date},{build.Results_ready},{build.Submitter}\n";
            }

            if (options.Output.ToLower().Equals("csv"))
            {
                File.WriteAllText($"{options.Filename}.csv", output);
            }
            else
            {
                System.Console.WriteLine(output);
            }
            return 1;
        }

        static int GetFlaws(GetFlawOptions options)
        {
            var repo = _serviceProvider.GetService<IVeracodeRepository>();
            var flaws = repo.GetFlaws(""+options.BuildId);

            if (options.FixForPolicy)
                flaws = flaws.Where(x => bool.Parse(x.Affects_policy_compliance.ToLower())).ToArray();

            var output = "Issueid, Sourcefile, Line, " +
                "Severity, Affects_policy_compliance, Categoryid, Categoryname, " +
                "Cia_impact, Count, Cweid, Date_first_occurrence, " +
                "ExploitLevel, Functionprototype, Functionrelativelocation, " +
                "Grace_period_expires, Mitigation_status, Mitigation_status_desc, Module, " +
                "Note, Pcirelated, Remediationeffort, Scope, " +
                "Type\n";
            foreach (var flaw in flaws)
            {
                output += $"{flaw.Issueid},{flaw.Sourcefile},{flaw.Line}," +
                    $"{flaw.Severity},{flaw.Affects_policy_compliance},{flaw.Categoryid},{flaw.Categoryname}," +
                    $"{flaw.Cia_impact},{flaw.Count},{flaw.Cweid},{flaw.Date_first_occurrence}," +
                    $"{flaw.ExploitLevel},\"{flaw.Functionprototype}\"," +
                    $"{flaw.Functionrelativelocation},{flaw.Grace_period_expires}," +
                    $"{flaw.Mitigation_status},{flaw.Mitigation_status_desc}, {flaw.Module}, " +
                    $"{flaw.Note}, {flaw.Pcirelated}, {flaw.Remediationeffort}," +
                    $"{flaw.Scope}, {flaw.Type}"+
                    $"\n";
            }

            if (options.Output.ToLower().Equals("csv"))
            {
                File.WriteAllText($"{options.Filename}.csv", output);
            }
            else
            {
                System.Console.WriteLine(output);
            }
            return 1;
        }

        static int GetLatestFlaws(GetLatestFlawsOptions options)
        {
            var repo = _serviceProvider.GetService<IVeracodeRepository>();
            var apps = repo.GetAllApps().Where(x => x.App_name.Contains(options.NamePattern));

            if (options.NamePattern != "")
                apps = apps.Where(x => x.App_name.Contains(options.NamePattern)).ToArray();

            foreach (var app in apps)
            {
                var buildid = repo.GetAllBuildsForApp("" + app.App_id).OrderBy(x => x.Build_id).First().Build_id;
                var flaws = repo.GetFlaws(buildid);

                var output = "Issueid, Sourcefile, Line, " +
                               "Severity, Affects_policy_compliance, Categoryid, Categoryname, " +
                               "Cia_impact, Count, Cweid, Date_first_occurrence, " +
                               "Description, ExploitLevel, Functionprototype, Functionrelativelocation, " +
                               "Grace_period_expires, Mitigation_status, Mitigation_status_desc, Module, " +
                               "Note, Pcirelated, Remediationeffort, Scope, " +
                               "Type\n";
                foreach (var flaw in flaws)
                {
                    output += $"{flaw.Issueid},{flaw.Sourcefile},{flaw.Line}," +
                        $"{flaw.Severity},{flaw.Affects_policy_compliance},{flaw.Categoryid},{flaw.Categoryname}," +
                        $"{flaw.Cia_impact},{flaw.Count},{flaw.Cweid},{flaw.Date_first_occurrence}," +
                        $"\"{flaw.Description}\",{flaw.ExploitLevel},\"{flaw.Functionprototype}\"," +
                        $"{flaw.Functionrelativelocation},{flaw.Grace_period_expires}," +
                        $"{flaw.Mitigation_status},{flaw.Mitigation_status_desc}, {flaw.Module}, " +
                        $"{flaw.Note}, {flaw.Pcirelated}, {flaw.Remediationeffort}," +
                        $"{flaw.Scope}, {flaw.Type}" +
                        $"\n";

                    File.WriteAllText($"{options.Filename}.csv", output);
                }
            }
            return 1;
        }

        static int HandleParseError(IEnumerable<Error> errs)
        {
            return 1;
        }
    }
}
using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using VeracodeService;
using VeracodeService.Repositories;
using VeracodeWebhooks.Configuration;
using System.Linq;
using VeraConsole.Options;
using VeraConsole.Helpers;
using VeracodeService.Models;
using VeraConsole.Commands;

namespace VeraConsole
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
            serviceCollection.AddScoped<IReporting, Reporting>();
            _serviceProvider = serviceCollection.BuildServiceProvider();

            var reportingCommands = _serviceProvider.GetService<IReporting>();

            Parser.Default.ParseArguments<
                GetAppsOptions, 
                GetBuildOptions, 
                GetTriageFlawsOptions, 
                PolicySummaryOptions,
                SourceFileSummaryOptions,
                DuplicateFlawOptions>(args)
                .MapResult(
                  (GetAppsOptions opts) => GetApps(opts),
                  (GetBuildOptions opts) => GetBuilds(opts),
                  (GetTriageFlawsOptions opts) => reportingCommands.TriageFlaws(opts),
                  (PolicySummaryOptions opts) => reportingCommands.PolicySummary(opts),
                  (SourceFileSummaryOptions opts) => reportingCommands.SourceFileSummary(opts),
                  (DuplicateFlawOptions opts) => reportingCommands.DuplicateFlaws(opts),
                  errs => HandleParseError(errs));
        }

        static int GetApps(GetAppsOptions options)
        {
            var repo = _serviceProvider.GetService<IVeracodeRepository>();
            var apps = repo.GetAllApps().Where(x => x.App_name.Contains(options.NamePattern));

            if(options.NamePattern != "")
                apps = apps.Where(x => x.App_name.Contains(options.NamePattern)).ToArray();

            var output = new CsvHelper().ToCsv(apps);

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
            var output = new CsvHelper().ToCsv(builds);

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
               
        static int HandleParseError(IEnumerable<Error> errs)
        {
            return 1;
        }
    }
}
using com.veracode.apiwrapper;
using Microsoft.Extensions.Options;
using VeracodeWebhooks.Configuration;

namespace VeracodeService
{
    public interface IVeracodeWrapper
    {
        string GetAppList();
        string GetBuildList(string appId);
        string GetDetailedResults(string buildId);
        string GetSummaryResults(string buildId);
        string GetMitigationInfo(string build_id, string flaw_id_list);
    }

    public class VeracodeWrapper : IVeracodeWrapper
    {
        private UploadAPIWrapper _uploadAPIWrapper;
        private MitigationAPIWrapper _mitigationAPIWrapper;
        private ResultsAPIWrapper _resultsAPIWrapper;

        public VeracodeWrapper(IOptions<VeracodeConfiguration> config)
        {
            _resultsAPIWrapper = CreateWrapper<ResultsAPIWrapper>(config.Value.ApiId, config.Value.ApiKey);
            _uploadAPIWrapper = CreateWrapper<UploadAPIWrapper>(config.Value.ApiId, config.Value.ApiKey);
            _mitigationAPIWrapper = CreateWrapper<MitigationAPIWrapper>(config.Value.ApiId, config.Value.ApiKey);
        }

        public string GetAppList()
        {
            return _uploadAPIWrapper.GetAppList();
        }

        public string GetBuildList(string appId)
        {
            return _uploadAPIWrapper.GetBuildList(appId);
        }

        public string GetDetailedResults(string buildId)
        {
            return _resultsAPIWrapper.DetailedReport(buildId);
        }

        public string GetSummaryResults(string buildId)
        {
            return _resultsAPIWrapper.SummaryReport(buildId);
        }

        public string GetMitigationInfo(string build_id, string flaw_id_list)
        {
            return _mitigationAPIWrapper.GetMitigationInfo(build_id, flaw_id_list);
        }

        private T CreateWrapper<T>(string apiId, string apiKey) where T : AbstractAPIWrapper, new()
        {
            var wrapper = new T();
            wrapper.SetUpApiCredentials(apiId, apiKey);
            return wrapper;
        }

    }

}

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VeracodeService.Models
{
    [XmlRoot(ElementName = "analysis_unit", Namespace = "https://analysiscenter.veracode.com/schema/4.0/buildinfo")]
    public class Analysis_unit
    {
        [XmlAttribute(AttributeName = "analysis_type")]
        [JsonProperty]
        public string Analysis_type { get; set; }
        [XmlAttribute(AttributeName = "published_date")]
        [JsonProperty]
        public string Published_date { get; set; }
        [XmlAttribute(AttributeName = "published_date_sec")]
        [JsonProperty]
        public string Published_date_sec { get; set; }
        [XmlAttribute(AttributeName = "status")]
        [JsonProperty]
        public string Status { get; set; }
        [XmlAttribute(AttributeName = "engine_version")]
        [JsonProperty]
        public string Engine_version { get; set; }
    }

    [XmlRoot(ElementName = "build", Namespace = "https://analysiscenter.veracode.com/schema/4.0/buildinfo")]
    public class Build
    {
        [XmlElement(ElementName = "analysis_unit", Namespace = "https://analysiscenter.veracode.com/schema/4.0/buildinfo")]
        [JsonProperty]
        public Analysis_unit Analysis_unit { get; set; }
        [XmlAttribute(AttributeName = "version")]
        [JsonProperty]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "build_id")]
        [JsonProperty]
        public string Build_id { get; set; }
        [XmlAttribute(AttributeName = "submitter")]
        [JsonProperty]
        public string Submitter { get; set; }
        [XmlAttribute(AttributeName = "platform")]
        [JsonProperty]
        public string Platform { get; set; }
        [XmlAttribute(AttributeName = "lifecycle_stage")]
        [JsonProperty]
        public string Lifecycle_stage { get; set; }
        [XmlAttribute(AttributeName = "results_ready")]
        [JsonProperty]
        public string Results_ready { get; set; }
        [XmlAttribute(AttributeName = "policy_name")]
        [JsonProperty]
        public string Policy_name { get; set; }
        [XmlAttribute(AttributeName = "policy_version")]
        [JsonProperty]
        public string Policy_version { get; set; }
        [XmlAttribute(AttributeName = "policy_compliance_status")]
        [JsonProperty]
        public string Policy_compliance_status { get; set; }
        [XmlAttribute(AttributeName = "policy_updated_date")]
        [JsonProperty]
        public string Policy_updated_date { get; set; }
        [XmlAttribute(AttributeName = "rules_status")]
        [JsonProperty]
        public string Rules_status { get; set; }
        [XmlAttribute(AttributeName = "grace_period_expired")]
        [JsonProperty]
        public string Grace_period_expired { get; set; }
        [XmlAttribute(AttributeName = "scan_overdue")]
        [JsonProperty]
        public string Scan_overdue { get; set; }
        [XmlAttribute(AttributeName = "legacy_scan_engine")]
        [JsonProperty]
        public string Legacy_scan_engine { get; set; }
        [XmlAttribute(AttributeName = "launch_date")]
        [JsonProperty]
        public string Launch_date { get; set; }
    }

    [XmlRoot(ElementName = "buildlist", Namespace = "https://analysiscenter.veracode.com/schema/2.0/buildlist")]
    public class BuildList
    {
        [XmlElement(ElementName = "build", Namespace = "https://analysiscenter.veracode.com/schema/2.0/buildlist")]
        public List<Build> Builds { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }

        [XmlAttribute(AttributeName = "buildlist_version")]
        public string Buildlist_version { get; set; }

        [XmlAttribute(AttributeName = "account_id")]
        public string Account_id { get; set; }

        [XmlAttribute(AttributeName = "app_id")]
        public string App_id { get; set; }

        [XmlAttribute(AttributeName = "app_name")]
        public string App_name { get; set; }
    }


    [XmlRoot(ElementName = "buildinfo", Namespace = "https://analysiscenter.veracode.com/schema/4.0/buildinfo")]
    public class Buildinfo
    {
        [XmlElement(ElementName = "build", Namespace = "https://analysiscenter.veracode.com/schema/4.0/buildinfo")]
        [JsonProperty]
        public List<Build> Builds { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "buildinfo_version")]
        [JsonProperty]
        public string Buildinfo_version { get; set; }
        [XmlAttribute(AttributeName = "account_id")]
        [JsonProperty]
        public string Account_id { get; set; }
        [XmlAttribute(AttributeName = "app_id")]
        [JsonProperty]
        public string App_id { get; set; }
        [XmlAttribute(AttributeName = "build_id")]
        [JsonProperty]
        public string Build_id { get; set; }
    }
}


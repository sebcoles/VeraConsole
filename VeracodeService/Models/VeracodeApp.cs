using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VeracodeService.Models
{
    [XmlRoot(ElementName = "app", Namespace = "https://analysiscenter.veracode.com/schema/2.0/applist")]
    public class VeracodeApp
    {
        [JsonProperty]
        [XmlAttribute(AttributeName = "app_id")]
        public string App_id { get; set; }
        [JsonProperty]
        [XmlAttribute(AttributeName = "app_name")]
        public string App_name { get; set; }
        [XmlAttribute(AttributeName = "policy_updated_date")]
        [JsonProperty]
        public string Policy_updated_date { get; set; }
    }

    [XmlRoot(ElementName = "applist", Namespace = "https://analysiscenter.veracode.com/schema/2.0/applist")]
    public class AppList
    {
        [JsonProperty]
        [XmlElement(ElementName = "app", Namespace = "https://analysiscenter.veracode.com/schema/2.0/applist")]
        public List<VeracodeApp> Apps { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "applist_version")]
        [JsonProperty]
        public string Applist_version { get; set; }
        [XmlAttribute(AttributeName = "account_id")]
        [JsonProperty]
        public string Account_id { get; set; }
    }
}

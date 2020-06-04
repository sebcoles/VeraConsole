using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace VeracodeService.Models
{

    [XmlRoot(ElementName = "issue", Namespace = "https://analysiscenter.veracode.com/schema/mitigationinfo/1.0")]
    public class Issue
    {
        [XmlAttribute(AttributeName = "flaw_id")]
        public string Flaw_id { get; set; }
        [XmlAttribute(AttributeName = "category")]
        public string Category { get; set; }
        [XmlElement(ElementName = "mitigation_action", Namespace = "https://analysiscenter.veracode.com/schema/mitigationinfo/1.0")]
        public List<MitigationAction> MitigationActions { get; set; }
    }

    [XmlRoot(ElementName = "mitigation_action", Namespace = "https://analysiscenter.veracode.com/schema/mitigationinfo/1.0")]
    public class MitigationAction
    {
        [XmlAttribute(AttributeName = "action")]
        public string Action { get; set; }
        [XmlAttribute(AttributeName = "desc")]
        public string Desc { get; set; }
        [XmlAttribute(AttributeName = "reviewer")]
        public string Reviewer { get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }

        [XmlIgnore]
        public DateTime DateObject => DateTime.ParseExact(Date, "yyyy-MM-dd HH:mm:ss",
            CultureInfo.InvariantCulture).AddHours(5);

        [XmlAttribute(AttributeName = "comment")]
        public string Comment { get; set; }
    }

    [XmlRoot(ElementName = "mitigationinfo", Namespace = "https://analysiscenter.veracode.com/schema/mitigationinfo/1.0")]
    public class Mitigation
    {
        [XmlElement(ElementName = "issue", Namespace = "https://analysiscenter.veracode.com/schema/mitigationinfo/1.0")]
        public List<Issue> Issue { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "mitigationinfo_version")]
        public string Mitigationinfo_version { get; set; }
        [XmlAttribute(AttributeName = "build_id")]
        public string Build_id { get; set; }
    }

}


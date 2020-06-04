using System.Collections.Generic;
using System.Xml.Serialization;

namespace VeracodeService.Models
{
	[XmlRoot(ElementName = "module", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Module
	{
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "compiler")]
		public string Compiler { get; set; }
		[XmlAttribute(AttributeName = "os")]
		public string Os { get; set; }
		[XmlAttribute(AttributeName = "architecture")]
		public string Architecture { get; set; }
		[XmlAttribute(AttributeName = "loc")]
		public string Loc { get; set; }
		[XmlAttribute(AttributeName = "score")]
		public string Score { get; set; }
		[XmlAttribute(AttributeName = "numflawssev0")]
		public string Numflawssev0 { get; set; }
		[XmlAttribute(AttributeName = "numflawssev1")]
		public string Numflawssev1 { get; set; }
		[XmlAttribute(AttributeName = "numflawssev2")]
		public string Numflawssev2 { get; set; }
		[XmlAttribute(AttributeName = "numflawssev3")]
		public string Numflawssev3 { get; set; }
		[XmlAttribute(AttributeName = "numflawssev4")]
		public string Numflawssev4 { get; set; }
		[XmlAttribute(AttributeName = "numflawssev5")]
		public string Numflawssev5 { get; set; }
	}

	[XmlRoot(ElementName = "modules", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Modules
	{
		[XmlElement(ElementName = "module", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public List<Module> Module { get; set; }
	}

	[XmlRoot(ElementName = "static-analysis", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Staticanalysis
	{
		[XmlElement(ElementName = "modules", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Modules Modules { get; set; }
		[XmlAttribute(AttributeName = "rating")]
		public string Rating { get; set; }
		[XmlAttribute(AttributeName = "score")]
		public string Score { get; set; }
		[XmlAttribute(AttributeName = "submitted_date")]
		public string Submitted_date { get; set; }
		[XmlAttribute(AttributeName = "published_date")]
		public string Published_date { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
		[XmlAttribute(AttributeName = "next_scan_due")]
		public string Next_scan_due { get; set; }
		[XmlAttribute(AttributeName = "analysis_size_bytes")]
		public string Analysis_size_bytes { get; set; }
		[XmlAttribute(AttributeName = "engine_version")]
		public string Engine_version { get; set; }
	}

	[XmlRoot(ElementName = "severity", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Severity
	{
		[XmlAttribute(AttributeName = "level")]
		public string Level { get; set; }
		[XmlElement(ElementName = "category", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public List<Category> Category { get; set; }
	}

	[XmlRoot(ElementName = "para", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Para
	{
		[XmlAttribute(AttributeName = "text")]
		public string Text { get; set; }
		[XmlElement(ElementName = "bulletitem", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public List<Bulletitem> Bulletitem { get; set; }
	}

	[XmlRoot(ElementName = "desc", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Desc
	{
		[XmlElement(ElementName = "para", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public List<Para> Para { get; set; }
	}

	[XmlRoot(ElementName = "recommendations", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Recommendations
	{
		[XmlElement(ElementName = "para", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public List<Para> Para { get; set; }
	}

	[XmlRoot(ElementName = "text", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Text
	{
		[XmlAttribute(AttributeName = "text")]
		public string _text { get; set; }
	}

	[XmlRoot(ElementName = "description", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Description
	{
		[XmlElement(ElementName = "text", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Text Text { get; set; }
	}

	[XmlRoot(ElementName = "annotation", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Annotation
	{
		[XmlAttribute(AttributeName = "action")]
		public string Action { get; set; }
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName = "user")]
		public string User { get; set; }
		[XmlAttribute(AttributeName = "date")]
		public string Date { get; set; }
	}

	[XmlRoot(ElementName = "annotations", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Annotations
	{
		[XmlElement(ElementName = "annotation", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Annotation Annotation { get; set; }
	}

	[XmlRoot(ElementName = "flaw", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Flaw
	{
		[XmlElement(ElementName = "annotations", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Annotations Annotations { get; set; }
		[XmlAttribute(AttributeName = "severity")]
		public string Severity { get; set; }
		[XmlAttribute(AttributeName = "categoryname")]
		public string Categoryname { get; set; }
		[XmlAttribute(AttributeName = "count")]
		public string Count { get; set; }
		[XmlAttribute(AttributeName = "issueid")]
		public string Issueid { get; set; }
		[XmlAttribute(AttributeName = "module")]
		public string Module { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName = "note")]
		public string Note { get; set; }
		[XmlAttribute(AttributeName = "cweid")]
		public string Cweid { get; set; }
		[XmlAttribute(AttributeName = "remediationeffort")]
		public string Remediationeffort { get; set; }
		[XmlAttribute(AttributeName = "exploitLevel")]
		public string ExploitLevel { get; set; }
		[XmlAttribute(AttributeName = "categoryid")]
		public string Categoryid { get; set; }
		[XmlAttribute(AttributeName = "pcirelated")]
		public string Pcirelated { get; set; }
		[XmlAttribute(AttributeName = "date_first_occurrence")]
		public string Date_first_occurrence { get; set; }
		[XmlAttribute(AttributeName = "remediation_status")]
		public string Remediation_status { get; set; }
		[XmlAttribute(AttributeName = "cia_impact")]
		public string Cia_impact { get; set; }
		[XmlAttribute(AttributeName = "grace_period_expires")]
		public string Grace_period_expires { get; set; }
		[XmlAttribute(AttributeName = "affects_policy_compliance")]
		public string Affects_policy_compliance { get; set; }
		[XmlAttribute(AttributeName = "mitigation_status")]
		public string Mitigation_status { get; set; }
		[XmlAttribute(AttributeName = "mitigation_status_desc")]
		public string Mitigation_status_desc { get; set; }
		[XmlAttribute(AttributeName = "sourcefile")]
		public string Sourcefile { get; set; }
		[XmlAttribute(AttributeName = "line")]
		public string Line { get; set; }
		[XmlAttribute(AttributeName = "sourcefilepath")]
		public string Sourcefilepath { get; set; }
		[XmlAttribute(AttributeName = "scope")]
		public string Scope { get; set; }
		[XmlAttribute(AttributeName = "functionprototype")]
		public string Functionprototype { get; set; }
		[XmlAttribute(AttributeName = "functionrelativelocation")]
		public string Functionrelativelocation { get; set; }
	}

	[XmlRoot(ElementName = "staticflaws", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Staticflaws
	{
		[XmlElement(ElementName = "flaw", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public List<Flaw> Flaw { get; set; }
	}

	[XmlRoot(ElementName = "cwe", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Cwe
	{
		[XmlElement(ElementName = "description", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Description Description { get; set; }
		[XmlElement(ElementName = "staticflaws", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Staticflaws Staticflaws { get; set; }
		[XmlAttribute(AttributeName = "cweid")]
		public string Cweid { get; set; }
		[XmlAttribute(AttributeName = "cwename")]
		public string Cwename { get; set; }
		[XmlAttribute(AttributeName = "pcirelated")]
		public string Pcirelated { get; set; }
		[XmlAttribute(AttributeName = "owasp2013")]
		public string Owasp2013 { get; set; }
		[XmlAttribute(AttributeName = "sans")]
		public string Sans { get; set; }
		[XmlAttribute(AttributeName = "owasp")]
		public string Owasp { get; set; }
		[XmlAttribute(AttributeName = "certjava")]
		public string Certjava { get; set; }
		[XmlAttribute(AttributeName = "owaspmobile")]
		public string Owaspmobile { get; set; }
	}

	[XmlRoot(ElementName = "category", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Category
	{
		[XmlElement(ElementName = "desc", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Desc Desc { get; set; }
		[XmlElement(ElementName = "recommendations", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Recommendations Recommendations { get; set; }
		[XmlElement(ElementName = "cwe", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public List<Cwe> Cwe { get; set; }
		[XmlAttribute(AttributeName = "categoryid")]
		public string Categoryid { get; set; }
		[XmlAttribute(AttributeName = "categoryname")]
		public string Categoryname { get; set; }
		[XmlAttribute(AttributeName = "pcirelated")]
		public string Pcirelated { get; set; }
	}

	[XmlRoot(ElementName = "bulletitem", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Bulletitem
	{
		[XmlAttribute(AttributeName = "text")]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "flaw-status", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Flawstatus
	{
		[XmlAttribute(AttributeName = "new")]
		public string New { get; set; }
		[XmlAttribute(AttributeName = "reopen")]
		public string Reopen { get; set; }
		[XmlAttribute(AttributeName = "open")]
		public string Open { get; set; }
		[XmlAttribute(AttributeName = "cannot-reproduce")]
		public string Cannotreproduce { get; set; }
		[XmlAttribute(AttributeName = "fixed")]
		public string Fixed { get; set; }
		[XmlAttribute(AttributeName = "total")]
		public string Total { get; set; }
		[XmlAttribute(AttributeName = "not_mitigated")]
		public string Not_mitigated { get; set; }
		[XmlAttribute(AttributeName = "sev-1-change")]
		public string Sev1change { get; set; }
		[XmlAttribute(AttributeName = "sev-2-change")]
		public string Sev2change { get; set; }
		[XmlAttribute(AttributeName = "sev-3-change")]
		public string Sev3change { get; set; }
		[XmlAttribute(AttributeName = "sev-4-change")]
		public string Sev4change { get; set; }
		[XmlAttribute(AttributeName = "sev-5-change")]
		public string Sev5change { get; set; }
	}

	[XmlRoot(ElementName = "customfield", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Customfield
	{
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName = "customfields", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Customfields
	{
		[XmlElement(ElementName = "customfield", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public List<Customfield> Customfield { get; set; }
	}

	[XmlRoot(ElementName = "file_path", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class File_path
	{
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName = "file_paths", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class File_paths
	{
		[XmlElement(ElementName = "file_path", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public List<File_path> File_path { get; set; }
	}

	[XmlRoot(ElementName = "license", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class License
	{
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "spdx_id")]
		public string Spdx_id { get; set; }
		[XmlAttribute(AttributeName = "license_url")]
		public string License_url { get; set; }
		[XmlAttribute(AttributeName = "risk_rating")]
		public string Risk_rating { get; set; }
	}

	[XmlRoot(ElementName = "licenses", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Licenses
	{
		[XmlElement(ElementName = "license", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public List<License> License { get; set; }
	}

	[XmlRoot(ElementName = "component", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Component
	{
		[XmlElement(ElementName = "file_paths", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public File_paths File_paths { get; set; }
		[XmlElement(ElementName = "licenses", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Licenses Licenses { get; set; }
		[XmlElement(ElementName = "violated_policy_rules", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public string Violated_policy_rules { get; set; }
		[XmlAttribute(AttributeName = "component_id")]
		public string Component_id { get; set; }
		[XmlAttribute(AttributeName = "file_name")]
		public string File_name { get; set; }
		[XmlAttribute(AttributeName = "sha1")]
		public string Sha1 { get; set; }
		[XmlAttribute(AttributeName = "vulnerabilities")]
		public string _Vulnerabilities { get; set; }
		[XmlElement(ElementName = "vulnerabilities", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Vulnerabilities Vulnerabilities { get; set; }
		[XmlAttribute(AttributeName = "max_cvss_score")]
		public string Max_cvss_score { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
		[XmlAttribute(AttributeName = "library")]
		public string Library { get; set; }
		[XmlAttribute(AttributeName = "vendor")]
		public string Vendor { get; set; }
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName = "added_date")]
		public string Added_date { get; set; }
		[XmlAttribute(AttributeName = "component_affects_policy_compliance")]
		public string Component_affects_policy_compliance { get; set; }
		[XmlAttribute(AttributeName = "new")]
		public string New { get; set; }
	}

	[XmlRoot(ElementName = "vulnerability", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Vulnerability
	{
		[XmlAttribute(AttributeName = "cve_id")]
		public string Cve_id { get; set; }
		[XmlAttribute(AttributeName = "cvss_score")]
		public string Cvss_score { get; set; }
		[XmlAttribute(AttributeName = "severity")]
		public string Severity { get; set; }
		[XmlAttribute(AttributeName = "cwe_id")]
		public string Cwe_id { get; set; }
		[XmlAttribute(AttributeName = "first_found_date")]
		public string First_found_date { get; set; }
		[XmlAttribute(AttributeName = "cve_summary")]
		public string Cve_summary { get; set; }
		[XmlAttribute(AttributeName = "severity_desc")]
		public string Severity_desc { get; set; }
		[XmlAttribute(AttributeName = "mitigation")]
		public string Mitigation { get; set; }
		[XmlAttribute(AttributeName = "vulnerability_affects_policy_compliance")]
		public string Vulnerability_affects_policy_compliance { get; set; }
	}

	[XmlRoot(ElementName = "vulnerabilities", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Vulnerabilities
	{
		[XmlElement(ElementName = "vulnerability", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public List<Vulnerability> Vulnerability { get; set; }
	}

	[XmlRoot(ElementName = "vulnerable_components", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Vulnerable_components
	{
		[XmlElement(ElementName = "component", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public List<Component> Component { get; set; }
	}

	[XmlRoot(ElementName = "software_composition_analysis", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class Software_composition_analysis
	{
		[XmlElement(ElementName = "vulnerable_components", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Vulnerable_components Vulnerable_components { get; set; }
		[XmlAttribute(AttributeName = "third_party_components")]
		public string Third_party_components { get; set; }
		[XmlAttribute(AttributeName = "violate_policy")]
		public string Violate_policy { get; set; }
		[XmlAttribute(AttributeName = "components_violated_policy")]
		public string Components_violated_policy { get; set; }
	}

	[XmlRoot(ElementName = "detailedreport", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
	public class DetailedReport
	{
		[XmlElement(ElementName = "static-analysis", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Staticanalysis Staticanalysis { get; set; }
		[XmlElement(ElementName = "severity", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public List<Severity> Severity { get; set; }
		[XmlElement(ElementName = "flaw-status", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Flawstatus Flawstatus { get; set; }
		[XmlElement(ElementName = "customfields", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Customfields Customfields { get; set; }
		[XmlElement(ElementName = "software_composition_analysis", Namespace = "https://www.veracode.com/schema/reports/export/1.0")]
		public Software_composition_analysis Software_composition_analysis { get; set; }
		[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsi { get; set; }
		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }
		[XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string SchemaLocation { get; set; }
		[XmlAttribute(AttributeName = "report_format_version")]
		public string Report_format_version { get; set; }
		[XmlAttribute(AttributeName = "account_id")]
		public string Account_id { get; set; }
		[XmlAttribute(AttributeName = "app_name")]
		public string App_name { get; set; }
		[XmlAttribute(AttributeName = "app_id")]
		public string App_id { get; set; }
		[XmlAttribute(AttributeName = "analysis_id")]
		public string Analysis_id { get; set; }
		[XmlAttribute(AttributeName = "static_analysis_unit_id")]
		public string Static_analysis_unit_id { get; set; }
		[XmlAttribute(AttributeName = "sandbox_id")]
		public string Sandbox_id { get; set; }
		[XmlAttribute(AttributeName = "first_build_submitted_date")]
		public string First_build_submitted_date { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
		[XmlAttribute(AttributeName = "build_id")]
		public string Build_id { get; set; }
		[XmlAttribute(AttributeName = "submitter")]
		public string Submitter { get; set; }
		[XmlAttribute(AttributeName = "platform")]
		public string Platform { get; set; }
		[XmlAttribute(AttributeName = "assurance_level")]
		public string Assurance_level { get; set; }
		[XmlAttribute(AttributeName = "business_criticality")]
		public string Business_criticality { get; set; }
		[XmlAttribute(AttributeName = "generation_date")]
		public string Generation_date { get; set; }
		[XmlAttribute(AttributeName = "veracode_level")]
		public string Veracode_level { get; set; }
		[XmlAttribute(AttributeName = "total_flaws")]
		public string Total_flaws { get; set; }
		[XmlAttribute(AttributeName = "flaws_not_mitigated")]
		public string Flaws_not_mitigated { get; set; }
		[XmlAttribute(AttributeName = "teams")]
		public string Teams { get; set; }
		[XmlAttribute(AttributeName = "life_cycle_stage")]
		public string Life_cycle_stage { get; set; }
		[XmlAttribute(AttributeName = "planned_deployment_date")]
		public string Planned_deployment_date { get; set; }
		[XmlAttribute(AttributeName = "last_update_time")]
		public string Last_update_time { get; set; }
		[XmlAttribute(AttributeName = "is_latest_build")]
		public string Is_latest_build { get; set; }
		[XmlAttribute(AttributeName = "policy_name")]
		public string Policy_name { get; set; }
		[XmlAttribute(AttributeName = "policy_version")]
		public string Policy_version { get; set; }
		[XmlAttribute(AttributeName = "policy_compliance_status")]
		public string Policy_compliance_status { get; set; }
		[XmlAttribute(AttributeName = "policy_rules_status")]
		public string Policy_rules_status { get; set; }
		[XmlAttribute(AttributeName = "grace_period_expired")]
		public string Grace_period_expired { get; set; }
		[XmlAttribute(AttributeName = "scan_overdue")]
		public string Scan_overdue { get; set; }
		[XmlAttribute(AttributeName = "business_owner")]
		public string Business_owner { get; set; }
		[XmlAttribute(AttributeName = "business_unit")]
		public string Business_unit { get; set; }
		[XmlAttribute(AttributeName = "tags")]
		public string Tags { get; set; }
		[XmlAttribute(AttributeName = "legacy_scan_engine")]
		public string Legacy_scan_engine { get; set; }
	}
}

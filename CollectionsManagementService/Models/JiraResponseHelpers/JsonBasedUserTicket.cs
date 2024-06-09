using System.Text.Json.Serialization;

namespace CollectionsManagementService.Models.JiraResponseHelpers;

public class JsonBasedUserTicket
{
    [JsonPropertyName("fields")]
    public IssueFields Fields { get; set; }

    public JsonBasedUserTicket(string summary, string reporterId, 
        string description, string link,
        string priorityValue, string collectionName)
    {
        Fields = new IssueFields
        {
            Project = new Issuetype { Id = "10000" },
            Issuetype = new Issuetype { Id = "10006" },
            Reporter = new Issuetype { Id = reporterId },
            Summary = summary,
            Description = description,
            Customfield10033 = link,
            Customfield10035 = collectionName,
            Customfield10039 = new Customfield100 { Value = priorityValue },
            Customfield10040 = new Customfield100 { Value = "Opened" }
        };
    }
}

public partial class IssueFields
{
    [JsonPropertyName("assignee")]
    public object Assignee { get; set; }

    [JsonPropertyName("project")]
    public Issuetype Project { get; set; }

    [JsonPropertyName("issuetype")]
    public Issuetype Issuetype { get; set; }

    [JsonPropertyName("summary")]
    public string Summary { get; set; }

    [JsonPropertyName("reporter")]
    public Issuetype Reporter { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("customfield_10033")]
    public string Customfield10033 { get; set; }

    [JsonPropertyName("customfield_10040")]
    public Customfield100 Customfield10040 { get; set; }

    [JsonPropertyName("customfield_10039")]
    public Customfield100 Customfield10039 { get; set; }

    [JsonPropertyName("customfield_10035")]
    public string Customfield10035 { get; set; }
}

public partial class Customfield100
{
    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public partial class Issuetype
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
}

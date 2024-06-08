using System.Text.Json.Serialization;

namespace CollectionsManagementService.Models.JiraResponseHelpers;

public class JsonBasedUserTicket
{
    [JsonPropertyName("fields")]
    public Fields Fields { get; set; }

    public JsonBasedUserTicket(string summary, string reporterId, 
        string description, string link,
        string priorityValue, string collectionName)
    {
        Fields = new Fields
        {
            Project = new OnlyIdField { Id = "10000" },
            Issuetype = new OnlyIdField { Id = "10006" },
            Reporter = new OnlyIdField { Id = reporterId },
            Summary = summary,
            Description = description,
            Link = link,
            CollectionName = collectionName,
            Priority = new CustomFieldIdValuePair { Value = priorityValue },
            Status = new CustomFieldIdValuePair { Value = "Opened" }
        };
    }
}

public class Fields
{
    [JsonPropertyName("assignee")]
    public OnlyIdField Assignee { get; set; }

    [JsonPropertyName("project")]
    public OnlyIdField Project { get; set; }

    [JsonPropertyName("issuetype")]
    public OnlyIdField Issuetype { get; set; }

    [JsonPropertyName("summary")]
    public string Summary { get; set; }

    [JsonPropertyName("reporter")]
    public OnlyIdField Reporter { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("customfield_10033")]
    public string Link { get; set; }

    [JsonPropertyName("customfield_10040")]
    public CustomFieldIdValuePair Status { get; set; }

    [JsonPropertyName("customfield_10039")]
    public CustomFieldIdValuePair Priority { get; set; }

    [JsonPropertyName("customfield_10035")]
    public string CollectionName { get; set; }
}

public class OnlyIdField
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
}

public class CustomFieldIdValuePair
{
    [JsonPropertyName("value")]
    public string Value { get; set; }
}

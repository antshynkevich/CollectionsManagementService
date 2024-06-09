using System.Text.Json.Serialization;

namespace CollectionsManagementService.Models.JiraResponseHelpers;

public class IssueCreationResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("self")]
    public string Self { get; set; }
}

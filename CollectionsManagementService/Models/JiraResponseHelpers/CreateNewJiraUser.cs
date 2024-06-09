using System.Text.Json.Serialization;

namespace CollectionsManagementService.Models.JiraResponseHelpers;

public class CreateNewJiraUser
{
    [JsonPropertyName("emailAddress")]
    public string EmailAddress { get; set; }

    [JsonPropertyName("products")]
    public List<string> Products { get; set; }
}

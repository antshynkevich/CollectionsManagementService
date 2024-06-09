namespace CollectionsManagementService.Models.JiraResponseHelpers;

using System.Text.Json;
using System.Text.Json.Serialization;

public class JiraUser
{
    [JsonPropertyName("accountId")]
    public string AccountId { get; set; }

    [JsonPropertyName("emailAddress")]
    public string EmailAddress { get; set; }

    public static JiraUser FromJson(string json) => JsonSerializer.Deserialize<JiraUser>(json);
}

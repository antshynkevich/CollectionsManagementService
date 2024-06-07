using CollectionsManagementService.Models.JiraResponseHelpers;
using System.Text;
using System.Text.Json;

namespace CollectionsManagementService.Services;

public class JiraService
{
    private readonly string _jiraBaseUrl = "https://integration-collection.atlassian.net/rest/api/2";
    private readonly string _searchByEmail = "/user/search?query=";
    private readonly string _apiToken;
    private readonly string _login;

    public JiraService()
    {
        _apiToken = DotNetEnv.Env.GetString("TokenApi");
        _login = DotNetEnv.Env.GetString("JiraLogin");
    }

    public async Task<string> GetUserIdFromJiraByEmailAsync(string userEmailAddress)
    {
        using var client = new HttpClient();
        var byteArray = Encoding.ASCII.GetBytes($"{_login}:{_apiToken}");
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        var userExistResponse = await client.GetAsync($"{_jiraBaseUrl}{_searchByEmail}{userEmailAddress}");
        var content = await userExistResponse.Content.ReadAsStringAsync();

        var jiraUserId = string.Empty;
        var isResponseLong = content.Length > 2;
        JiraUser? jiraUser = null;
        
        if (isResponseLong) 
        {
            try
            {
                jiraUser = JiraUser.FromJson(content[1..^1]);
                jiraUserId = jiraUser?.AccountId ?? string.Empty;
            }
            catch (Exception exc)
            {
                jiraUser = null;
                await Console.Out.WriteLineAsync($"Something went wrong during user receiving from jira {exc}"); 
            }
        }

        if (jiraUser != null && jiraUserId.Length > 0)
        {
            jiraUserId = jiraUser.AccountId ?? string.Empty;
        }
        else
        {
            var createUser = new CreateNewJiraUser()
            {
                EmailAddress = userEmailAddress,
                Products = ["jira-software"]
            };

            string userJsonBody = JsonSerializer.Serialize(createUser);
            HttpContent userRequestBody = new StringContent(userJsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage userCreationResponse = await client.PostAsync($"{_jiraBaseUrl}/user", userRequestBody);
            content = await userCreationResponse.Content.ReadAsStringAsync();
            var newJiraUser = JiraUser.FromJson(content);
            jiraUserId = newJiraUser?.AccountId ?? string.Empty;
        }

        return jiraUserId;
    }

    public async Task<string> CreateIssueAndReturnLinkAsync(JsonBasedUserTicket userTicket)
    {
        using var client = new HttpClient();
        var byteArray = Encoding.ASCII.GetBytes($"{_login}:{_apiToken}");
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        string issueJsonBody = JsonSerializer.Serialize(userTicket);
        HttpContent issueRequestBody = new StringContent(issueJsonBody, Encoding.UTF8, "application/json");
        HttpResponseMessage issueCreationResponse = await client.PostAsync($"{_jiraBaseUrl}/issue", issueRequestBody);
        using var stream = await issueCreationResponse.Content.ReadAsStreamAsync();
        var deserializedObject = await JsonSerializer.DeserializeAsync<IssueCreationResponse>(stream);
        var ticketKey = deserializedObject?.Key ?? "";
        return $"https://integration-collection.atlassian.net/browse/{ticketKey}";
    }
}

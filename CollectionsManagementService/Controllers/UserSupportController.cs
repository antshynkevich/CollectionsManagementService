using CollectionsManagementService.Models.JiraResponseHelpers;
using CollectionsManagementService.Services;
using CollectionsManagementService.VievModels;
using DataORMLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace CollectionsManagementService.Controllers;

[Authorize(Policy = "UserNotBlocked")]
public class UserSupportController : Controller
{
    private readonly string _jiraAdminAccountId;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JiraService _jiraService;

    public UserSupportController(UserManager<ApplicationUser> userManager, JiraService jiraService)
    {
        _userManager = userManager;
        _jiraAdminAccountId = DotNetEnv.Env.GetString("JiraAdminAccountId");
        _jiraService = jiraService;
    }

    public IActionResult Index(string linkForHelp, string collectionName)
    {
        if (!linkForHelp.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
        {
            linkForHelp = "http://" + linkForHelp;
        }

        var userTicket = new UserTicketViewModel() 
        {
            PageLinkUserNeedHelp = linkForHelp,
            CollectionName = collectionName ?? ""
        };

        return View(userTicket);
    }

    [HttpPost]
    public async Task<IActionResult> PostIssue(UserTicketViewModel userTicket)
    {
        var currentUser = await _userManager.GetUserAsync(User);
        var currentUserEmail = currentUser?.Email;
        var jiraUserId = await _jiraService.GetUserIdFromJiraByEmailAsync(currentUserEmail);
        // TODO: add jira user id to my ApplicationUser using claim

        var newTicket = new JsonBasedUserTicket(
            summary: userTicket.Summary,
            description: userTicket.Description ?? "No description",
            link: userTicket.PageLinkUserNeedHelp,
            priorityValue: userTicket.PriorityId,
            collectionName: userTicket.CollectionName,
            reporterId: jiraUserId,
            jiraAdminAccountId: _jiraAdminAccountId
        );

        var ticketLink = await _jiraService.CreateIssueAndReturnLinkAsync(newTicket);
        return RedirectToAction(nameof(RegisteredIssue), new { ticketLink });
    }

    public IActionResult RegisteredIssue(string ticketLink)
    {
        return View("Message", ticketLink);
    }
}

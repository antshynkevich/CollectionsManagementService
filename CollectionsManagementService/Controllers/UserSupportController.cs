using CollectionsManagementService.Models.JiraResponseHelpers;
using CollectionsManagementService.Services;
using CollectionsManagementService.VievModels;
using DataORMLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CollectionsManagementService.Controllers;

[Authorize(Policy = "UserNotBlocked")]
public class UserSupportController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JiraService _jiraService;

    public UserSupportController(UserManager<ApplicationUser> userManager, JiraService jiraService)
    {
        _userManager = userManager;
        _jiraService = jiraService;
    }

    [HttpGet]
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

        var jiraUserIdClaimName = "jirauserid";
        var claims = await _userManager.GetClaimsAsync(currentUser);
        var jiraUserIdFromDb = claims.FirstOrDefault(c => c.Type == jiraUserIdClaimName)?.Value ?? null;

        var jiraUserId = "";
        if (jiraUserIdFromDb is not null)
        {
            jiraUserId = jiraUserIdFromDb;
        }
        else
        {
            jiraUserId = await _jiraService.GetUserIdFromJiraByEmailAsync(currentUserEmail);
            await _userManager.AddClaimAsync(currentUser, new Claim(jiraUserIdClaimName, jiraUserId));
        }

        var newTicket = new JsonBasedUserTicket(
            summary: userTicket.Summary,
            description: userTicket.Description ?? "No description",
            link: userTicket.PageLinkUserNeedHelp,
            priorityValue: userTicket.PriorityId,
            collectionName: userTicket.CollectionName,
            reporterId: jiraUserId
        );

        var ticketLink = await _jiraService.CreateIssueAndReturnLinkAsync(newTicket);
        return RedirectToAction(nameof(RegisteredIssue), new { ticketLink });
    }

    [HttpGet]
    public IActionResult RegisteredIssue(string ticketLink)
    {
        return View("Message", ticketLink);
    }
}

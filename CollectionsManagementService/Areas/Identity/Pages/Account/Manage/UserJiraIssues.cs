using CollectionsManagementService.Services;
using DataORMLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CollectionsManagementService.Areas.Identity.Pages.Account.Manage
{
    public class UserJiraIssuesModel : PageModel
    {
        private readonly JiraService _jiraService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserJiraIssuesModel(UserManager<ApplicationUser> userManager, 
            JiraService jiraService)
        {
            _userManager = userManager;
            _jiraService = jiraService;

        }

        [BindProperty]
        public List<IssueData> IssuesVm { get; set; } = [];
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public int PageSize { get; set; } = 6;
        public int PageNumber { get; set; }

        public async Task<IActionResult> OnGetAsync(int? pageNumber)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var jiraUserIdClaimName = "jirauserid";
            var claims = await _userManager.GetClaimsAsync(currentUser);
            var jiraUserIdFromDb = claims.FirstOrDefault(c => c.Type == jiraUserIdClaimName)?.Value ?? null;
            if (jiraUserIdFromDb == null) return Page();

            var numberOfIssues = await _jiraService.IssueTotalNumberByReporterIdAsync(jiraUserIdFromDb);
            TotalPages = (int)Math.Ceiling(numberOfIssues / (double)PageSize);
            PageIndex = pageNumber ?? 1;


            var issues = await _jiraService.GetIssuesOnPagesByUserIdAsync(jiraUserIdFromDb, pageNumber ?? 1, PageSize);

            IssuesVm = issues.Issues.Select(i => new IssueData
            {
                Created = i.Fields.Created[..^18],
                Status = i.Fields.Customfield10040.Value,
                Summary = i.Fields.Summary,
                IssueLink = $"https://integration-collection.atlassian.net/browse/{i.Key}",
                CollectionName = i.Fields.Customfield10035
            }).ToList();

            return Page();
        }

        public class IssueData
        {
            public string Status { get; set; }
            public string Summary { get; set; }
            public string Created { get; set; }
            public string IssueLink { get; set; }
            public string CollectionName { get; set; }
        }
    }
}

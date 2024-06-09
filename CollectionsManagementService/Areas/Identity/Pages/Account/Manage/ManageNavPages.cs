using Microsoft.AspNetCore.Mvc.Rendering;

namespace  CollectionsManagementService.Areas.Identity.Pages.Account.Manage
{
    public static class ManageNavPages
    {
        public static string Index => "Index";
        public static string Email => "Email";
        public static string ChangePassword => "ChangePassword";
        public static string UserJiraIssues => "UserJiraIssues";
        public static string UserTokenApi => "UserTokenApi";
        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string EmailNavClass(ViewContext viewContext) => PageNavClass(viewContext, Email);
        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);
        public static string UserApiTokenNavClass(ViewContext viewContext) => PageNavClass(viewContext, UserTokenApi);
        public static string UserJiraIssuesNavClass(ViewContext viewContext) => PageNavClass(viewContext, UserJiraIssues);
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}

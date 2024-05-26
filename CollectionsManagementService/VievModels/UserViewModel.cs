namespace CollectionsManagementService.VievModels;

public class UserViewModel
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsBlocked { get; set; }
}

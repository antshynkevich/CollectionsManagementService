using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CollectionsManagementService.VievModels;

public class UserTicketViewModel
{
    public UserTicketViewModel()
    {
        PriorityItems =
        [
            new() {
                Value = "Low",
                Text = "Low"
            },
            new() {
                Value = "Average",
                Text = "Average"
            },
            new() {
                Value = "High",
                Text = "High"
            }
        ];
    }

    [Required]
    [StringLength(100, MinimumLength = 2, ErrorMessage =
        "Your issue summary must be at least 10 characters long but less than 100 characters.")]
    public string Summary { get; set; }
    [Required]
    public string PageLinkUserNeedHelp { get; set; }
    [BindRequired]
    public string PriorityId { get; set; }
    public string CollectionName { get; set; } = "No collection name";
    [StringLength(250, ErrorMessage =
        "The description of your issue must be less than 250 characters.")]
    public string? Description { get; set; } = "No description";
    public List<SelectListItem> PriorityItems { get; set; }
}

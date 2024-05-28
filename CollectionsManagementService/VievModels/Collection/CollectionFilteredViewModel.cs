using DataORMLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectionsManagementService.VievModels.Collection;

public class CollectionFilteredViewModel
{
    public CollectionFilteredViewModel(List<Category> categories, List<CollectionViewModel> collections)
    {
        Categories =
        [
            new()
            {
                Value = null,
                Text = "All categories"
            },
            .. categories.Select(cat => new SelectListItem { Value = cat.CategoryId.ToString(), Text = cat.Name }),
        ];

        Collections = collections;
    }

    public List<SelectListItem> Categories { get; set; }
    public List<CollectionViewModel> Collections { get; set; }
    public int? CategoryId { get; set; } = null;
}

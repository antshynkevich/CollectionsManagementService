using DataORMLayer;
using System.ComponentModel.DataAnnotations;

namespace CollectionsManagementService.VievModels.Collection;

public class UpdateCollectionViewModel
{
    public Guid CollectionId { get; set; }
    [Required]
    [MaxLength(Constants.NameSize)]
    public string Name { get; set; }
    [Required]
    [MaxLength(Constants.DescriptionSize)]
    public string Description { get; set; }
    //public int CategoryId { get; set; }
    // TODO: add category update
    public IFormFile Image { get; set; }
    public string? ImageUrl { get; set; }
    public List<CollectionFieldViewModel> CollectionFields { get; set; }
}

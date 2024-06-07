using CollectionsManagementService.VievModels.Collection;
using DataORMLayer;
using DataORMLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace CollectionsManagementService.VievModels.Item;

public class UpdateItemViewModel : IUserIdContained, ICollectionNameContains
{
    public Guid ItemId { get; set; }
    [Required]
    [MaxLength(Constants.NameSize)]
    public string ItemName { get; set; }
    public List<UpdateItemField<int>> IntFields { get; set; } = [];
    public List<UpdateItemField<string>> StringFields { get; set; } = [];
    public List<UpdateItemField<string>> TextFields { get; set; } = [];
    public List<UpdateItemField<DateOnly>> DateFields { get; set; } = [];
    public List<UpdateItemField<bool>> BoolFields { get; set; } = [];
    public string? UserId { get; set; }
    public string CollectionName { get; set; }
    public Guid CollectionId { get; set; }
}

public class UpdateItemField<T> : ItemFieldViewModel<T>
{
    public Guid ItemFieldId { get; set; }
}

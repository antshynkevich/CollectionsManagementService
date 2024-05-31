using DataORMLayer;
using DataORMLayer.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CollectionsManagementService.VievModels.Collection;

public class CreateCollectionViewModel
{
    private static readonly int typesOfCustomFields = 5;
    private static readonly int oneTypeCustomFields = 3;

    public CreateCollectionViewModel() { }

    public CreateCollectionViewModel(List<Category> categories)
    {
        Categories.AddRange(categories.Select(cat => new SelectListItem { Value = cat.CategoryId.ToString(), Text = cat.Name }));
        ConfigureCollectionFields();
    }

    public CollectionFieldViewModel[] CollectionFields { get; set; }
        = new CollectionFieldViewModel[oneTypeCustomFields * typesOfCustomFields];

    [Required(ErrorMessage = "Collection name is required")]
    [MaxLength(Constants.NameSize)]
    public string Name { get; set; }
    [Required(ErrorMessage = "Description is required")]
    [MaxLength(Constants.DescriptionSize)]
    public string Description { get; set; }
    [BindRequired]
    public int CategoryId { get; set; }
    public List<SelectListItem> Categories { get; set; } = [];
    public IFormFile? Image { get; set; }
    public string? ImageUrl { get; set; }

    private void ConfigureCollectionFields()
    {
        int fieldsIndex = 0;
        foreach (var fieldType in (FieldType[])Enum.GetValues(typeof(FieldType)))
        {
            for (int i = 0; i < oneTypeCustomFields; i++)
            {
                CollectionFields[fieldsIndex] = new CollectionFieldViewModel
                {
                    FieldType = fieldType
                };

                fieldsIndex++;
            }
        }
    }
}

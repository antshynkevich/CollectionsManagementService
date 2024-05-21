using DataORMLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectionsManagementService.VievModels;

public class CreateCollectionViewModel
{
    private static readonly int typesOfCustomFields = 5;
    private static readonly int oneTypeCustomFields = 3;

    public CreateCollectionViewModel() { }

    public CreateCollectionViewModel(List<Category> categories)
    {
        Categories = categories.Select(cat => new SelectListItem { Value = cat.CategoryId.ToString(), Text = cat.Name });
        ConfigureCollectionFields();
    }

    public CollectionFieldViewModel[] CollectionFields { get; set; } 
        = new CollectionFieldViewModel[oneTypeCustomFields * typesOfCustomFields];
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CategoryId { get; set; } = string.Empty;
    public IEnumerable<SelectListItem> Categories { get; set; } = [];

    private void ConfigureCollectionFields()
    {
        int fieldsIndex = 0;
        foreach (var fieldType in (FieldType[])Enum.GetValues(typeof(FieldType)))
        {
            for (int i = 0; i < 3; i++)
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

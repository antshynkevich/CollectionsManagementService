using DataORMLayer.Models;

namespace CollectionsManagementService.VievModels;

public class CreateCollectionViewModel
{
    public CreateCollectionViewModel()
    {
        ConfigureCollectionFields();
    }

    public CreateCollectionFieldViewModel[] CollectionFields { get; set; } 
        = new CreateCollectionFieldViewModel[3 * 5];
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }

    public Collection MapToCollection()
    {
        var collectionId = Guid.NewGuid();
        var collectionFields = CollectionFields
            .Where(f => f.IsFieldNeeded)
            .Select(f => new CollectionField
            {
                CollectionFieldId = Guid.NewGuid(),
                CollectionId = collectionId,
                FieldName = f.Name,
                FieldType = f.FieldType
            }).ToArray();
        var collection = new Collection()
        {
            CollectionId = collectionId,
            Name = this.Name,
            Description = this.Description,
            CategoryId = this.CategoryId,
            CollectionFields = collectionFields
        };

        return collection;
    }

    private void ConfigureCollectionFields()
    {
        int fieldsIndex = 0;
        foreach (var fieldType in (FieldType[])Enum.GetValues(typeof(FieldType)))
        {
            for (int i = 0; i < 3; i++)
            {
                CollectionFields[fieldsIndex] = new CreateCollectionFieldViewModel
                {
                    FieldType = fieldType
                };

                fieldsIndex++;
            }
        }
    }
}

public class CreateCollectionFieldViewModel
{
    public FieldType FieldType { get; set; }
    public string Name { get; set; }
    public bool IsFieldNeeded { get; set; }
}

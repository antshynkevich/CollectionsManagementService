using CollectionsManagementService.Services.Interfaces;
using CollectionsManagementService.VievModels.Item;
using DataORMLayer.Models;
using DataORMLayer.Models.CustomDataFields;

namespace CollectionsManagementService.Services;

public class ItemMapper : IItemMapper
{
    public DetailedItemViewModel MapToDetailedItemViewModel(Item item)
    {
        return new DetailedItemViewModel
        {
            ItemId = item.ItemId,
            ItemName = item.Name,
            CollectionId = item.CollectionId,
            CollectionName = item.Collection.Name,
            UserId = item.Collection.UserId,
            CreationDate = item.CreationDate,
            IntegerFields = item.IntegerFields.Select(MapItemFieldHelper<int>.MapToItemViewModel).ToList(),
            BoolFields = item.BooleanFields.Select(MapItemFieldHelper<bool>.MapToItemViewModel).ToList(),
            DateFields = item.DateFields.Select(MapItemFieldHelper<DateOnly>.MapToItemViewModel).ToList(),
            StringFields = item.StringFields.Select(MapItemFieldHelper<string>.MapToItemViewModel).ToList(),
            TextFields = item.TextFields.Select(MapItemFieldHelper<string>.MapToItemViewModel).ToList(),
        };
    }

    public CreateItemViewModel MapToCreateItemViewModel(Collection collection)
    {
        var collectionFields = collection.CollectionFields;
        var boolFields = MapItemFieldHelper<bool>.MapToItemFields(collectionFields, FieldType.Boolean);
        var stringFields = MapItemFieldHelper<string>.MapToItemFields(collectionFields, FieldType.String);
        var dateFields = MapItemFieldHelper<DateOnly>.MapToItemFields(collectionFields, FieldType.Date);
        foreach (var fieldWithIdViewModel in dateFields)
        {
            fieldWithIdViewModel.Value = DateOnly.FromDateTime(DateTime.UtcNow);
        }
        var intFields = MapItemFieldHelper<int>.MapToItemFields(collectionFields, FieldType.Integer);
        var textFields = MapItemFieldHelper<string>.MapToItemFields(collectionFields, FieldType.Text);

        return new CreateItemViewModel
        {
            BoolFields = boolFields,
            StringFields = stringFields,
            IntegerFields = intFields,
            DateFields = dateFields,
            TextFields = textFields,
            CollectionId = collection.CollectionId
        };
    }

    public Item MapToItem(CreateItemViewModel viewModel)
    {
        var itemId = Guid.NewGuid();
        var item = new Item
        {
            ItemId = itemId,
            CollectionId = viewModel.CollectionId,
            Name = viewModel.Name,
            CreationDate = DateTime.UtcNow,
        };

        if (viewModel.IntegerFields != null)
        {
            item.IntegerFields = viewModel.IntegerFields.Select(x => new IntegerField()
            {
                ItemId = itemId,
                CollectionFieldId = x.CollectionFieldId,
                Value = x.Value,
                IntegerFieldId = Guid.NewGuid()
            }).ToList();
        }

        if (viewModel.StringFields != null)
        {
            item.StringFields = viewModel.StringFields.Select(x => new StringField()
            {
                ItemId = itemId,
                CollectionFieldId = x.CollectionFieldId,
                Value = x.Value,
                StringFieldId = Guid.NewGuid()
            }).ToList();
        }

        if (viewModel.TextFields != null)
        {
            item.TextFields = viewModel.TextFields.Select(x => new TextField()
            {
                ItemId = itemId,
                CollectionFieldId = x.CollectionFieldId,
                Value = x.Value,
                TextFieldId = Guid.NewGuid()
            }).ToList();
        }

        if (viewModel.DateFields != null)
        {
            item.DateFields = viewModel.DateFields.Select(x => new DateField()
            {
                ItemId = itemId,
                CollectionFieldId = x.CollectionFieldId,
                Value = x.Value,
                DateFieldId = Guid.NewGuid()
            }).ToList();
        }

        if (viewModel.BoolFields != null)
        {
            item.BooleanFields = viewModel.BoolFields.Select(x => new BooleanField()
            {
                ItemId = itemId,
                CollectionFieldId = x.CollectionFieldId,
                Value = x.Value,
                BooleanFieldId = Guid.NewGuid()
            }).ToList();
        }

        return item;
    }

    public ItemViewModel MapToItemViewModel(Item item)
    {
        return new ItemViewModel
        {
            ItemId = item.ItemId,
            ItemName = item.Name,
            IntegerFields = item.IntegerFields.Select(MapItemFieldHelper<int>.MapToItemViewModel).ToList(),
            BoolFields = item.BooleanFields.Select(MapItemFieldHelper<bool>.MapToItemViewModel).ToList(),
            DateFields = item.DateFields.Select(MapItemFieldHelper<DateOnly>.MapToItemViewModel).ToList(),
            StringFields = item.StringFields.Select(MapItemFieldHelper<string>.MapToItemViewModel).ToList(),
            TextFields = item.TextFields.Select(MapItemFieldHelper<string>.MapToItemViewModel).ToList(),
            CreationDate = item.CreationDate
        };
    }

    public ItemSearchPageViewModel MapToItemFromSearch(Item item)
    {
        return new ItemSearchPageViewModel()
        {
            ItemId = item.ItemId,
            Name = item.Name,
            CreationDate = item.CreationDate,
            CollectionId = item.CollectionId,
            CollectionName = item.Collection.Name,
            StringFields = item.StringFields.Select(MapItemFieldHelper<string>.MapToItemViewModel).ToList(),
            TextFields = item.TextFields.Select(MapItemFieldHelper<string>.MapToItemViewModel).ToList(),
        };
    }

    public UpdateItemViewModel MapToUpdateItemViewModel(Item item)
    {
        var viewModel = new UpdateItemViewModel()
        {
            ItemName = item.Name,
            ItemId = item.ItemId,
            UserId = item.Collection.UserId,
            CollectionId = item.Collection.CollectionId,
            CollectionName = item.Collection.Name
        };

        viewModel.BoolFields = item.BooleanFields.Select(x => new UpdateItemField<bool>
        {
            ItemFieldId = x.BooleanFieldId,
            FieldType = x.CollectionField.FieldType.ToString(),
            FieldName = x.CollectionField.FieldName,
            Value = x.Value
        }).ToList();

        viewModel.TextFields = item.TextFields.Select(x => new UpdateItemField<string>
        {
            ItemFieldId = x.TextFieldId,
            FieldType = x.CollectionField.FieldType.ToString(),
            FieldName = x.CollectionField.FieldName,
            Value = x.Value
        }).ToList();

        viewModel.StringFields = item.StringFields.Select(x => new UpdateItemField<string>
        {
            ItemFieldId = x.StringFieldId,
            FieldType = x.CollectionField.FieldType.ToString(),
            FieldName = x.CollectionField.FieldName,
            Value = x.Value
        }).ToList();

        viewModel.DateFields = item.DateFields.Select(x => new UpdateItemField<DateOnly>
        {
            ItemFieldId = x.DateFieldId,
            FieldType = x.CollectionField.FieldType.ToString(),
            FieldName = x.CollectionField.FieldName,
            Value = x.Value
        }).ToList();

        viewModel.IntFields = item.IntegerFields.Select(x => new UpdateItemField<int>
        {
            ItemFieldId = x.IntegerFieldId,
            FieldType = x.CollectionField.FieldType.ToString(),
            FieldName = x.CollectionField.FieldName,
            Value = x.Value
        }).ToList();

        return viewModel;
    }

    public Item MapToItem(UpdateItemViewModel viewModel)
    {
        var item = new Item()
        {
            CollectionId = viewModel.CollectionId,
            Name = viewModel.ItemName,
            ItemId = viewModel.ItemId,
            IntegerFields = viewModel.IntFields.Select(x => 
                new IntegerField { IntegerFieldId = x.ItemFieldId, Value = x.Value }).ToList(),
            StringFields = viewModel.StringFields.Select(x =>
                new StringField { StringFieldId = x.ItemFieldId, Value = x.Value }).ToList(),
            TextFields = viewModel.TextFields.Select(x =>
                new TextField { TextFieldId = x.ItemFieldId, Value = x.Value }).ToList(),
            DateFields = viewModel.DateFields.Select(x =>
                new DateField { DateFieldId = x.ItemFieldId, Value = x.Value }).ToList(),
            BooleanFields = viewModel.BoolFields.Select(x =>
                new BooleanField { BooleanFieldId = x.ItemFieldId, Value = x.Value }).ToList(),
        };

        return item;
    }
}

﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataORMLayer.Models.CustomDataFields;

[Table("IntegerFields")]
public class IntegerField : IItemField<int>
{
    public Guid IntegerFieldId { get; set; }
    public Guid CollectionFieldId { get; set; }
    public Guid ItemId { get; set; }
    [Required]
    public int Value { get; set; }

    public CollectionField CollectionField { get; set; }
    public Item Item { get; set; }
}

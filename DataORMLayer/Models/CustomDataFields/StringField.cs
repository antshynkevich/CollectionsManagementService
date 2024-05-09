﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataORMLayer.Models.CustomDataFields;

[Table("StringFields")]
public class StringField
{
    public Guid StringFieldId { get; set; }
    public Guid CollectionFieldId { get; set; }
    public Guid ItemId { get; set; }
    [Required]
    [MaxLength(64)]
    public string Value { get; set; }

    public CollectionField CollectionField { get; set; }
    public Item Item { get; set; }
}

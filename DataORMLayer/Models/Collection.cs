﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataORMLayer.Models;

public class Collection : IUserIdContained
{
    public Guid CollectionId { get; set; }
    [Required]
    [MaxLength(Constants.NameSize)]
    public string Name { get; set; }
    public int CategoryId { get; set; }
    [MaxLength(Constants.DescriptionSize)]
    public string Description { get; set; }
    public string UserId { get; set; }
    [MaxLength(Constants.UrlSize)]
    public string? ImageUrl { get; set; }
    [Column(TypeName = "datetime2")]
    public DateTime CreationDate { get; set; }

    public Category Category { get; set; }
    public ICollection<Item> Items { get; set; }
    public ICollection<CollectionField> CollectionFields { get; set; }
    [ForeignKey(nameof(UserId))]
    public ApplicationUser ApplicationUser { get; set; }
}

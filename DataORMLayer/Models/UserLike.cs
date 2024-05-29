using System.ComponentModel.DataAnnotations.Schema;

namespace DataORMLayer.Models;

[Table("UserLikes")]
public class UserLike
{
    public Guid UserLikeId { get; set; }
    public string UserId { get; set; }
    public Guid ItemId { get; set; }
    [Column(TypeName = "datetime2")]
    public DateTime LikeDate { get; set; }

    public Item Item { get; set; }
    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; }
}

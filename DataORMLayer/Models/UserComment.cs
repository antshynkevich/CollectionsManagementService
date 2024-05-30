using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataORMLayer.Models;

[Table("UserComments")]
public class UserComment
{
    public Guid UserCommentId { get; set; }
    public string UserId { get; set; }
    public Guid ItemId { get; set; }
    [MaxLength(1024)]
    public string CommentText { get; set; }
    [Column(TypeName = "datetime2")]
    public DateTime PublicationDate { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; }
    public Item Item { get; set; }
}

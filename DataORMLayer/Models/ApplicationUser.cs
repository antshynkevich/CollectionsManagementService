using Microsoft.AspNetCore.Identity;

namespace DataORMLayer.Models;

public class ApplicationUser : IdentityUser 
{
    public ICollection<Collection> Collections { get; set; }
    public ICollection<UserLike> UserLikes { get; set; }
    public ICollection<UserComment> UserComments { get; set; }
}

using DataORMLayer.Models.CustomDataFields;
using DataORMLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DataORMLayer.EfCoreCode;

public static class ApplicationDbInitializer
{
    private static readonly string _userId1 = "950d7b27-1918-4296-9bd3-1d4e4de95f6a";
    private static readonly string _userId2 = "f3b759c7-4ee0-4326-989e-b9f8861e44c9";
    private static readonly string _userId3 = "87fdb39c-a62e-4559-a6cd-e7ae6c05f747";

    public static async Task SeedUsers(UserManager<ApplicationUser> userManager)
    {
        if (userManager.FindByIdAsync(_userId1).Result != null)
            return;

        var seedEmail1 = "admin.account@security.com";
        var seedPassword1 = "ABC3_xyz!com";
        var seedEmail2 = "egunner0@bandcamp.com";
        var seedPassword2 = "bZ9&<~&u8";
        var seedEmail3 = "slloyd1@google.co.uk";
        var seedPassword3 = "zR6=C/M,*oU,($";

        var user1 = new ApplicationUser
        {
            Id = _userId1,
            UserName = seedEmail1,
            Email = seedEmail1,
            NormalizedEmail = seedEmail1.ToUpper(),
            NormalizedUserName = seedEmail1.ToUpper()
        };

        await userManager.CreateAsync(user1, seedPassword1);
        var roleClaim1 = new Claim("role", "admin");
        var userName1 = new Claim("username", "Comrade Admin");
        await userManager.AddClaimAsync(user1, roleClaim1);
        await userManager.AddClaimAsync(user1, userName1);

        var user2 = new ApplicationUser
        {
            Id = _userId2,
            UserName = seedEmail2,
            Email = seedEmail2,
            NormalizedEmail = seedEmail2.ToUpper(),
            NormalizedUserName = seedEmail2.ToUpper()
        };

        await userManager.CreateAsync(user2, seedPassword2);
        var roleClaim2 = new Claim("role", "user");
        var userName2 = new Claim("username", "Errol Gunner");
        await userManager.AddClaimAsync(user2, roleClaim2);
        await userManager.AddClaimAsync(user2, userName2);

        var user3 = new ApplicationUser
        {
            Id = _userId3,
            UserName = seedEmail3,
            Email = seedEmail3,
            NormalizedEmail = seedEmail3.ToUpper(),
            NormalizedUserName = seedEmail3.ToUpper()
        };

        await userManager.CreateAsync(user3, seedPassword3);
        var blockedClaim = new Claim("blocked", "blocked");
        var userName3 = new Claim("username", "Stefanie Lloyd");
        var roleClaim3 = new Claim("role", "user");
        await userManager.AddClaimAsync(user3, roleClaim3);
        await userManager.AddClaimAsync(user3, userName3);
        await userManager.AddClaimAsync(user3, blockedClaim);
    }

    public static async Task Initialize(AppDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        dbContext.Database.EnsureCreated();
        if (dbContext.Collections.Any()) return;

        var collectonId1 = Guid.NewGuid();
        var collectonId2 = Guid.NewGuid();
        var collections = new List<Collection>()
        {
            new Collection
            {
                CollectionId = collectonId1,
                Name = "IMDb top 10 movies",
                CategoryId = 1,
                Description = "The description of the \"IMDb top 10 movies\" collection",
                UserId = _userId1,
                CreationDate = DateTime.UtcNow
            },
            new Collection
            {
                CollectionId = collectonId2,
                Name = "Art of Three Faiths",
                CategoryId = 2,
                Description = "A Torah, a Bible, and a Qur’an",
                UserId = _userId1,
                CreationDate = DateTime.UtcNow
            }
        };

        await dbContext.Collections.AddRangeAsync(collections);

        var stringFieldId = Guid.NewGuid();
        var intFieldId = Guid.NewGuid();
        var dateFieldId = Guid.NewGuid();
        var textFieldId = Guid.NewGuid();
        var textFieldId2 = Guid.NewGuid();

        var collectionFields = new List<CollectionField>()
        {
            new CollectionField
            {
                CollectionFieldId = stringFieldId,
                CollectionId = collectonId1,
                FieldName = "Movie Title",
                FieldType = FieldType.String,
            },
            new CollectionField
            {
                CollectionFieldId = intFieldId,
                CollectionId = collectonId1,
                FieldName = "IMDb Score",
                FieldType = FieldType.Integer,
            },
            new CollectionField
            {
                CollectionFieldId = dateFieldId,
                CollectionId = collectonId1,
                FieldName = "Relise date",
                FieldType = FieldType.Date,
            },
            new CollectionField
            {
                CollectionFieldId = textFieldId,
                CollectionId = collectonId1,
                FieldName = "Move plot",
                FieldType = FieldType.Text,
            },
            new CollectionField
            {
                CollectionFieldId = textFieldId2,
                CollectionId = collectonId2,
                FieldName = "Book's contents.",
                FieldType = FieldType.Text,
            }
        };

        await dbContext.CollectionFields.AddRangeAsync(collectionFields);

        var itemId1 = Guid.NewGuid();
        var itemId2 = Guid.NewGuid();
        var itemId3 = Guid.NewGuid();
        var itemId4 = Guid.NewGuid();

        var items = new List<Item>()
        {
            new Item
            {
                ItemId = itemId1,
                Name = "First position",
                CollectionId = collectonId1,
                CreationDate = DateTime.UtcNow
            },
            new Item
            {
                ItemId = itemId2,
                Name = "Second position",
                CollectionId = collectonId1,
                CreationDate = DateTime.UtcNow
            },
            new Item
            {
                ItemId = itemId3,
                Name = "3rd position",
                CollectionId = collectonId1,
                CreationDate = DateTime.UtcNow
            },
            new Item
            {
                ItemId = itemId4,
                Name = "Bible",
                CollectionId = collectonId2,
                CreationDate = DateTime.UtcNow
            }
        };

        await dbContext.Items.AddRangeAsync(items);

        var StringFieldId1 = Guid.NewGuid();
        var StringFieldId2 = Guid.NewGuid();
        var StringFieldId3 = Guid.NewGuid();

        var stringFields = new List<StringField>()
        {
            new StringField
            {
                StringFieldId = StringFieldId1,
                ItemId = itemId1,
                Value = "The Shawshank Redemption",
                CollectionFieldId = stringFieldId
            },
            new StringField
            {
                StringFieldId = StringFieldId2,
                ItemId = itemId2,
                Value = "The Godfather",
                CollectionFieldId = stringFieldId
            },
            new StringField
            {
                StringFieldId = StringFieldId3,
                ItemId = itemId3,
                Value = "The Dark Knight",
                CollectionFieldId = stringFieldId
            }
        };

        await dbContext.StringFields.AddRangeAsync(stringFields);

        var IntegerFieldId1 = Guid.NewGuid();
        var IntegerFieldId2 = Guid.NewGuid();
        var IntegerFieldId3 = Guid.NewGuid();

        var intFields = new List<IntegerField>()
        {
            new IntegerField
            {
                IntegerFieldId = IntegerFieldId1,
                ItemId = itemId1,
                Value = 93,
                CollectionFieldId = intFieldId
            },
            new IntegerField
            {
                IntegerFieldId = IntegerFieldId2,
                ItemId = itemId2,
                Value = 92,
                CollectionFieldId = intFieldId
            },
            new IntegerField
            {
                IntegerFieldId = IntegerFieldId3,
                ItemId = itemId3,
                Value = 90,
                CollectionFieldId = intFieldId
            }
        };

        await dbContext.IntegerFields.AddRangeAsync(intFields);

        var TextFieldId1 = Guid.NewGuid();
        var TextFieldId2 = Guid.NewGuid();
        var TextFieldId3 = Guid.NewGuid();
        var TextFieldId4 = Guid.NewGuid();

        var textFields = new List<TextField>()
        {
            new TextField
            {
                TextFieldId = TextFieldId1,
                ItemId = itemId1,
                Value = "Over the course of several years, two convicts form a friendship, " +
                "seeking consolation and, eventually, redemption through basic compassion.",
                CollectionFieldId = textFieldId
            },
            new TextField
            {
                TextFieldId = TextFieldId2,
                ItemId = itemId2,
                Value = "The aging patriarch of an organized crime dynasty transfers " +
                "control of his clandestine empire to his reluctant son.",
                CollectionFieldId = textFieldId
            },
            new TextField
            {
                TextFieldId = TextFieldId3,
                ItemId = itemId3,
                Value = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, " +
                "Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                CollectionFieldId = textFieldId
            },
            new TextField
            {
                TextFieldId = TextFieldId4,
                ItemId = itemId4,
                Value = "The Bible is a collection of religious texts or scriptures, some, all, or a variant of which are held to be sacred in " +
                "Christianity, Judaism, Samaritanism, Islam, the Baha'i Faith, and other Abrahamic religions.",
                CollectionFieldId = textFieldId2
            }
        };

        await dbContext.TextFields.AddRangeAsync(textFields);

        var DateFieldId1 = Guid.NewGuid();
        var DateFieldId2 = Guid.NewGuid();
        var DateFieldId3 = Guid.NewGuid();

        var dateFields = new List<DateField>
        {
            new DateField
            {
                DateFieldId = DateFieldId1,
                ItemId = itemId1,
                Value = new DateOnly(1994, 1, 1),
                CollectionFieldId = dateFieldId
            },
            new DateField
            {
                DateFieldId = DateFieldId2,
                ItemId = itemId2,
                Value = new DateOnly(1972, 1, 1),
                CollectionFieldId = dateFieldId
            },
            new DateField
            {
                DateFieldId = DateFieldId3,
                ItemId = itemId3,
                Value = new DateOnly(2008, 1, 1),
                CollectionFieldId = dateFieldId
            }
        };

        await dbContext.DateFields.AddRangeAsync(dateFields);

        await dbContext.SaveChangesAsync();
    }

    //public static void SeedData(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Category>().HasData(
    //        new Category { CategoryId = 1, Name = "Movies" },
    //        new Category { CategoryId = 2, Name = "Books" },
    //        new Category { CategoryId = 3, Name = "Clothes" },
    //        new Category { CategoryId = 4, Name = "Games, Toys, and Figures" },
    //        new Category { CategoryId = 5, Name = "Bills and Coins, Stamps" },
    //        new Category { CategoryId = 6, Name = "Music Albums, Clips, and Records" },
    //        new Category { CategoryId = 7, Name = "Product and Service Reviews" },
    //        new Category { CategoryId = 8, Name = "Cars and Vehicles" },
    //        new Category { CategoryId = 9, Name = "Dish Recipes" },
    //        new Category { CategoryId = 10, Name = "Firearms" },
    //        new Category { CategoryId = 11, Name = "Other" }
    //    );

    //    var collectonId1 = Guid.NewGuid();
    //    var collectonId2 = Guid.NewGuid();
    //    modelBuilder.Entity<Collection>().HasData(
    //        new Collection
    //        {
    //            CollectionId = collectonId1,
    //            Name = "IMDb top 10 movies",
    //            CategoryId = 1,
    //            Description = "The description of the \"IMDb top 10 movies\" collection",
    //            UserId = _userId,
    //            CreationDate = DateTime.UtcNow
    //        },
    //        new Collection
    //        {
    //            CollectionId = collectonId2,
    //            Name = "Art of Three Faiths",
    //            CategoryId = 2,
    //            Description = "A Torah, a Bible, and a Qur’an",
    //            UserId = _userId,
    //            CreationDate = DateTime.UtcNow
    //        }
    //    );

    //    var stringFieldId = Guid.NewGuid();
    //    var intFieldId = Guid.NewGuid();
    //    var dateFieldId = Guid.NewGuid();
    //    var textFieldId = Guid.NewGuid();
    //    var textFieldId2 = Guid.NewGuid();
    //    modelBuilder.Entity<CollectionField>().HasData(
    //        new CollectionField
    //        {
    //            CollectionFieldId = stringFieldId,
    //            CollectionId = collectonId1,
    //            FieldName = "Movie Title",
    //            FieldType = FieldType.String,
    //        },
    //        new CollectionField
    //        {
    //            CollectionFieldId = intFieldId,
    //            CollectionId = collectonId1,
    //            FieldName = "IMDb Score",
    //            FieldType = FieldType.Integer,
    //        },
    //        new CollectionField
    //        {
    //            CollectionFieldId = dateFieldId,
    //            CollectionId = collectonId1,
    //            FieldName = "Relise date",
    //            FieldType = FieldType.Date,
    //        },
    //        new CollectionField
    //        {
    //            CollectionFieldId = textFieldId,
    //            CollectionId = collectonId1,
    //            FieldName = "Move plot",
    //            FieldType = FieldType.Text,
    //        },
    //        new CollectionField
    //        {
    //            CollectionFieldId = textFieldId2,
    //            CollectionId = collectonId2,
    //            FieldName = "Book's contents.",
    //            FieldType = FieldType.Text,
    //        }
    //    );

    //    var itemId1 = Guid.NewGuid();
    //    var itemId2 = Guid.NewGuid();
    //    var itemId3 = Guid.NewGuid();
    //    var itemId4 = Guid.NewGuid();
    //    modelBuilder.Entity<Item>().HasData(
    //        new Item
    //        {
    //            ItemId = itemId1,
    //            Name = "First position",
    //            CollectionId = collectonId1,
    //            CreationDate = DateTime.UtcNow
    //        },
    //        new Item
    //        {
    //            ItemId = itemId2,
    //            Name = "Second position",
    //            CollectionId = collectonId1,
    //            CreationDate = DateTime.UtcNow
    //        },
    //        new Item
    //        {
    //            ItemId = itemId3,
    //            Name = "3rd position",
    //            CollectionId = collectonId1,
    //            CreationDate = DateTime.UtcNow
    //        },
    //        new Item
    //        {
    //            ItemId = itemId4,
    //            Name = "Bible",
    //            CollectionId = collectonId2,
    //            CreationDate = DateTime.UtcNow
    //        }
    //    );

    //    var StringFieldId1 = Guid.NewGuid();
    //    var StringFieldId2 = Guid.NewGuid();
    //    var StringFieldId3 = Guid.NewGuid();
    //    modelBuilder.Entity<StringField>().HasData(
    //        new StringField
    //        {
    //            StringFieldId = StringFieldId1,
    //            ItemId = itemId1,
    //            Value = "The Shawshank Redemption",
    //            CollectionFieldId = stringFieldId
    //        },
    //        new StringField
    //        {
    //            StringFieldId = StringFieldId2,
    //            ItemId = itemId2,
    //            Value = "The Godfather",
    //            CollectionFieldId = stringFieldId
    //        },
    //        new StringField
    //        {
    //            StringFieldId = StringFieldId3,
    //            ItemId = itemId3,
    //            Value = "The Dark Knight",
    //            CollectionFieldId = stringFieldId
    //        }
    //    );

    //    var IntegerFieldId1 = Guid.NewGuid();
    //    var IntegerFieldId2 = Guid.NewGuid();
    //    var IntegerFieldId3 = Guid.NewGuid();
    //    modelBuilder.Entity<IntegerField>().HasData(
    //        new IntegerField
    //        {
    //            IntegerFieldId = IntegerFieldId1,
    //            ItemId = itemId1,
    //            Value = 93,
    //            CollectionFieldId = intFieldId
    //        },
    //        new IntegerField
    //        {
    //            IntegerFieldId = IntegerFieldId2,
    //            ItemId = itemId2,
    //            Value = 92,
    //            CollectionFieldId = intFieldId
    //        },
    //        new IntegerField
    //        {
    //            IntegerFieldId = IntegerFieldId3,
    //            ItemId = itemId3,
    //            Value = 90,
    //            CollectionFieldId = intFieldId
    //        }
    //    );

    //    var DateFieldId1 = Guid.NewGuid();
    //    var DateFieldId2 = Guid.NewGuid();
    //    var DateFieldId3 = Guid.NewGuid();
    //    modelBuilder.Entity<DateField>().HasData(
    //        new DateField
    //        {
    //            DateFieldId = DateFieldId1,
    //            ItemId = itemId1,
    //            Value = new DateOnly(1994, 1, 1),
    //            CollectionFieldId = dateFieldId
    //        },
    //        new DateField
    //        {
    //            DateFieldId = DateFieldId2,
    //            ItemId = itemId2,
    //            Value = new DateOnly(1972, 1, 1),
    //            CollectionFieldId = dateFieldId
    //        },
    //        new DateField
    //        {
    //            DateFieldId = DateFieldId3,
    //            ItemId = itemId3,
    //            Value = new DateOnly(2008, 1, 1),
    //            CollectionFieldId = dateFieldId
    //        }
    //    );

    //    var TextFieldId1 = Guid.NewGuid();
    //    var TextFieldId2 = Guid.NewGuid();
    //    var TextFieldId3 = Guid.NewGuid();
    //    var TextFieldId4 = Guid.NewGuid();
    //    modelBuilder.Entity<TextField>().HasData(
    //        new TextField
    //        {
    //            TextFieldId = TextFieldId1,
    //            ItemId = itemId1,
    //            Value = "Over the course of several years, two convicts form a friendship, " +
    //            "seeking consolation and, eventually, redemption through basic compassion.",
    //            CollectionFieldId = textFieldId
    //        },
    //        new TextField
    //        {
    //            TextFieldId = TextFieldId2,
    //            ItemId = itemId2,
    //            Value = "The aging patriarch of an organized crime dynasty transfers " +
    //            "control of his clandestine empire to his reluctant son.",
    //            CollectionFieldId = textFieldId
    //        },
    //        new TextField
    //        {
    //            TextFieldId = TextFieldId3,
    //            ItemId = itemId3,
    //            Value = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, " +
    //            "Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
    //            CollectionFieldId = textFieldId
    //        },
    //        new TextField
    //        {
    //            TextFieldId = TextFieldId4,
    //            ItemId = itemId4,
    //            Value = "The Bible is a collection of religious texts or scriptures, some, all, or a variant of which are held to be sacred in " +
    //            "Christianity, Judaism, Samaritanism, Islam, the Baha'i Faith, and other Abrahamic religions.",
    //            CollectionFieldId = textFieldId2
    //        }
    //    );
    //}
}

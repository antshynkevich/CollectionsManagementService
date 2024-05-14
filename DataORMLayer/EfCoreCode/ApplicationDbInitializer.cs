using DataORMLayer.Models.CustomDataFields;
using DataORMLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DataORMLayer.EfCoreCode;

public static class ApplicationDbInitializer
{
    private static readonly string _userId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";

    public static async Task SeedUsers(UserManager<ApplicationUser> userManager)
    {
        if (userManager.FindByIdAsync(_userId).Result != null)
            return;

        var seedEmail = "admin@security.com";
        var seedPassword = "ABC3_xyz!com";

        if (userManager.FindByEmailAsync(seedEmail).Result == null)
        {
            var user = new ApplicationUser
            {
                Id = _userId,
                UserName = seedEmail,
                Email = seedEmail,
                NormalizedEmail = seedEmail.ToUpper(),
                NormalizedUserName = seedEmail.ToUpper()
            };

            await userManager.CreateAsync(user, seedPassword);
            var adminClaim = new Claim("UserIsAdminRequired", "Admin", ClaimValueTypes.Boolean);
            await userManager.AddClaimAsync(user, adminClaim);
        }
    }

    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Movies" },
            new Category { CategoryId = 2, Name = "Books" },
            new Category { CategoryId = 3, Name = "Clothes" },
            new Category { CategoryId = 4, Name = "Games, Toys, and Figures" },
            new Category { CategoryId = 5, Name = "Bills and Coins, Stamps" },
            new Category { CategoryId = 6, Name = "Music Albums, Clips, and Records" },
            new Category { CategoryId = 7, Name = "Firearms" },
            new Category { CategoryId = 8, Name = "Cars and Vehicles" },
            new Category { CategoryId = 99, Name = "Other" }
        );

        var collectonId1 = Guid.NewGuid();
        var collectonId2 = Guid.NewGuid();
        modelBuilder.Entity<Collection>().HasData(
            new Collection
            {
                CollectionId = collectonId1,
                Name = "IMDb top 10 movies",
                CategoryId = 1,
                Description = "The description of the \"IMDb top 10 movies\" collection",
                UserId = _userId
            },
            new Collection
            {
                CollectionId = collectonId2,
                Name = "Art of Three Faiths",
                CategoryId = 2,
                Description = "A Torah, a Bible, and a Qur’an",
                UserId = _userId
            }
        );

        var collectonFieldId1 = Guid.NewGuid();
        var collectonFieldId2 = Guid.NewGuid();
        var collectonFieldId3 = Guid.NewGuid();
        var collectonFieldId4 = Guid.NewGuid();
        modelBuilder.Entity<CollectionField>().HasData(
            new CollectionField
            {
                CollectionFieldId = collectonFieldId1,
                CollectionId = collectonId1,
                FieldName = "Movie Title",
                FieldType = FieldType.String,
            },
            new CollectionField
            {
                CollectionFieldId = collectonFieldId2,
                CollectionId = collectonId1,
                FieldName = "IMDb Score",
                FieldType = FieldType.Integer,
            },
            new CollectionField
            {
                CollectionFieldId = collectonFieldId3,
                CollectionId = collectonId1,
                FieldName = "Relise date",
                FieldType = FieldType.Date,
            },
            new CollectionField
            {
                CollectionFieldId = collectonFieldId4,
                CollectionId = collectonId1,
                FieldName = "Move plot",
                FieldType = FieldType.Text,
            }
        );

        var itemId1 = Guid.NewGuid();
        var itemId2 = Guid.NewGuid();
        var itemId3 = Guid.NewGuid();
        modelBuilder.Entity<Item>().HasData(
            new Item
            {
                ItemId = itemId1,
                Name = "First position",
                CollectionId = collectonId1
            },
            new Item
            {
                ItemId = itemId2,
                Name = "Second position",
                CollectionId = collectonId1
            },
            new Item
            {
                ItemId = itemId3,
                Name = "3rd position",
                CollectionId = collectonId1
            }
        );

        var StringFieldId1 = Guid.NewGuid();
        var StringFieldId2 = Guid.NewGuid();
        var StringFieldId3 = Guid.NewGuid();
        modelBuilder.Entity<StringField>().HasData(
            new StringField
            {
                StringFieldId = StringFieldId1,
                ItemId = itemId1,
                Value = "The Shawshank Redemption",
                CollectionFieldId = collectonFieldId1
            },
            new StringField
            {
                StringFieldId = StringFieldId2,
                ItemId = itemId2,
                Value = "The Godfather",
                CollectionFieldId = collectonFieldId1
            },
            new StringField
            {
                StringFieldId = StringFieldId3,
                ItemId = itemId3,
                Value = "The Dark Knight",
                CollectionFieldId = collectonFieldId1
            }
        );

        var IntegerFieldId1 = Guid.NewGuid();
        var IntegerFieldId2 = Guid.NewGuid();
        var IntegerFieldId3 = Guid.NewGuid();
        modelBuilder.Entity<IntegerField>().HasData(
            new IntegerField
            {
                IntegerFieldId = IntegerFieldId1,
                ItemId = itemId1,
                Value = 93,
                CollectionFieldId = collectonFieldId1
            },
            new IntegerField
            {
                IntegerFieldId = IntegerFieldId2,
                ItemId = itemId2,
                Value = 92,
                CollectionFieldId = collectonFieldId1
            },
            new IntegerField
            {
                IntegerFieldId = IntegerFieldId3,
                ItemId = itemId3,
                Value = 90,
                CollectionFieldId = collectonFieldId1
            }
        );

        var DateFieldId1 = Guid.NewGuid();
        var DateFieldId2 = Guid.NewGuid();
        var DateFieldId3 = Guid.NewGuid();
        modelBuilder.Entity<DateField>().HasData(
            new DateField
            {
                DateFieldId = DateFieldId1,
                ItemId = itemId1,
                Value = new DateTime(1994, 1, 1),
                CollectionFieldId = collectonFieldId1
            },
            new DateField
            {
                DateFieldId = DateFieldId2,
                ItemId = itemId2,
                Value = new DateTime(1972, 1, 1),
                CollectionFieldId = collectonFieldId1
            },
            new DateField
            {
                DateFieldId = DateFieldId3,
                ItemId = itemId3,
                Value = new DateTime(2008, 1, 1),
                CollectionFieldId = collectonFieldId1
            }
        );

        var TextFieldId1 = Guid.NewGuid();
        var TextFieldId2 = Guid.NewGuid();
        var TextFieldId3 = Guid.NewGuid();
        modelBuilder.Entity<TextField>().HasData(
            new TextField
            {
                TextFieldId = TextFieldId1,
                ItemId = itemId1,
                Value = "Over the course of several years, two convicts form a friendship, " +
                "seeking consolation and, eventually, redemption through basic compassion.",
                CollectionFieldId = collectonFieldId4
            },
            new TextField
            {
                TextFieldId = TextFieldId2,
                ItemId = itemId2,
                Value = "The aging patriarch of an organized crime dynasty transfers " +
                "control of his clandestine empire to his reluctant son.",
                CollectionFieldId = collectonFieldId4
            },
            new TextField
            {
                TextFieldId = TextFieldId3,
                ItemId = itemId3,
                Value = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, " +
                "Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                CollectionFieldId = collectonFieldId4
            }
        );
    }
}

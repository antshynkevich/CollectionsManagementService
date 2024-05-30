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
        await SeedNiceMovies(dbContext);
        await SeedReligionBooks(dbContext);
        await dbContext.SaveChangesAsync();
    }

    private static async Task SeedNiceMovies(AppDbContext dbContext)
    {
        var movieCollectonId = Guid.NewGuid();
        var movieStringFieldId1 = Guid.NewGuid();
        var movieStringFieldId2 = Guid.NewGuid();
        var movieIntFieldId1 = Guid.NewGuid();
        var movieIntFieldId3 = Guid.NewGuid();
        var movieBoolFieldId = Guid.NewGuid();
        var movieDateFieldId = Guid.NewGuid();
        var movieItemId1 = Guid.NewGuid();
        var movieItemId2 = Guid.NewGuid();
        var movieItemId3 = Guid.NewGuid();
        var movieItemId4 = Guid.NewGuid();
        var movieItemId5 = Guid.NewGuid();
        var movieItemId6 = Guid.NewGuid();
        var movieItemId7 = Guid.NewGuid();

        var movieCollection = new Collection
        {
            CollectionId = movieCollectonId,
            Name = "Top 7 Movies of the 20th Century",
            CategoryId = 1,
            Description = "This collection celebrates the cinematic masterpieces that defined the 20th century, showcasing a diverse range of genres and styles that have left an indelible mark on film history.",
            UserId = _userId2,
            CreationDate = new DateTime(2023, 06, 12)
        };

        var movieCollectionFields = new List<CollectionField>()
        {
            new CollectionField
            {
                CollectionFieldId = movieDateFieldId,
                CollectionId = movieCollectonId,
                FieldName = "Release Year",
                FieldType = FieldType.Date,
            },
            new CollectionField
            {
                CollectionFieldId = movieStringFieldId1,
                CollectionId = movieCollectonId,
                FieldName = "Director",
                FieldType = FieldType.String,
            },
            new CollectionField
            {
                CollectionFieldId = movieStringFieldId2,
                CollectionId = movieCollectonId,
                FieldName = "Genre",
                FieldType = FieldType.String,
            },
            new CollectionField
            {
                CollectionFieldId = movieIntFieldId1,
                CollectionId = movieCollectonId,
                FieldName = "IMDb Rating",
                FieldType = FieldType.Integer,
            },
            new CollectionField
            {
                CollectionFieldId = movieBoolFieldId,
                CollectionId = movieCollectonId,
                FieldName = "Is it in Color?",
                FieldType = FieldType.Boolean,
            },
            new CollectionField
            {
                CollectionFieldId = movieIntFieldId3,
                CollectionId = movieCollectonId,
                FieldName = "Runtime",
                FieldType = FieldType.Integer,
            },
        };

        var movieItems = new List<Item>()
        {
            new Item
            {
                ItemId = movieItemId1,
                Name = "The Godfather",
                CollectionId = movieCollectonId,
                CreationDate = new DateTime(2023, 07, 02)
            },
            new Item
            {
                ItemId = movieItemId2,
                Name = "TStar Wars: Episode IV - A New Hope",
                CollectionId = movieCollectonId,
                CreationDate = new DateTime(2023, 06, 15)
            },
            new Item
            {
                ItemId = movieItemId3,
                Name = "Schindler’s List",
                CollectionId = movieCollectonId,
                CreationDate = new DateTime(2024, 02, 22)
            },
            new Item
            {
                ItemId = movieItemId4,
                Name = "Titanic",
                CollectionId = movieCollectonId,
                CreationDate = new DateTime(2023, 07, 16)
            },
            new Item
            {
                ItemId = movieItemId5,
                Name = "Psycho",
                CollectionId = movieCollectonId,
                CreationDate = new DateTime(2023, 08, 02)
            },
            new Item
            {
                ItemId = movieItemId6,
                Name = "2001: A Space Odyssey",
                CollectionId = movieCollectonId,
                CreationDate = new DateTime(2023, 08, 18)
            },
            new Item
            {
                ItemId = movieItemId7,
                Name = "The Wizard of Oz",
                CollectionId = movieCollectonId,
                CreationDate = new DateTime(2023, 07, 14)
            },
        };

        var movieDateFields = new List<DateField>()
        {
            new DateField
            {
                DateFieldId = Guid.NewGuid(),
                ItemId = movieItemId1,
                Value = new DateOnly(1972, 01, 01),
                CollectionFieldId = movieDateFieldId
            },
            new DateField
            {
                DateFieldId = Guid.NewGuid(),
                ItemId = movieItemId2,
                Value = new DateOnly(1977, 01, 01),
                CollectionFieldId = movieDateFieldId
            },
            new DateField
            {
                DateFieldId = Guid.NewGuid(),
                ItemId = movieItemId3,
                Value = new DateOnly(1993, 01, 01),
                CollectionFieldId = movieDateFieldId
            },
            new DateField
            {
                DateFieldId = Guid.NewGuid(),
                ItemId = movieItemId4,
                Value = new DateOnly(1997, 01, 01),
                CollectionFieldId = movieDateFieldId
            },
            new DateField
            {
                DateFieldId = Guid.NewGuid(),
                ItemId = movieItemId5,
                Value = new DateOnly(1960, 01, 01),
                CollectionFieldId = movieDateFieldId
            },
            new DateField
            {
                DateFieldId = Guid.NewGuid(),
                ItemId = movieItemId6,
                Value = new DateOnly(1968, 01, 01),
                CollectionFieldId = movieDateFieldId
            },
            new DateField
            {
                DateFieldId = Guid.NewGuid(),
                ItemId = movieItemId7,
                Value = new DateOnly(1939, 01, 01),
                CollectionFieldId = movieDateFieldId
            }
        };

        var movieStringFields = new List<StringField>()
        {
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId1,
                Value = "Francis Ford Coppola",
                CollectionFieldId = movieStringFieldId1
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId1,
                Value = "Crime, Drama",
                CollectionFieldId = movieStringFieldId2
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId2,
                Value = "George Lucas",
                CollectionFieldId = movieStringFieldId1
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId2,
                Value = "Action, Adventure, Sci-Fi",
                CollectionFieldId = movieStringFieldId2
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId3,
                Value = "Steven Spielberg",
                CollectionFieldId = movieStringFieldId1
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId3,
                Value = "Biography, Drama, History",
                CollectionFieldId = movieStringFieldId2
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId4,
                Value = "James Cameron",
                CollectionFieldId = movieStringFieldId1
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId4,
                Value = "Drama, Romance",
                CollectionFieldId = movieStringFieldId2
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId5,
                Value = "Alfred Hitchcock",
                CollectionFieldId = movieStringFieldId1
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId5,
                Value = "Horror, Mystery, Thriller",
                CollectionFieldId = movieStringFieldId2
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId6,
                Value = "Stanley Kubrick",
                CollectionFieldId = movieStringFieldId1
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId6,
                Value = "Adventure, Sci-Fi",
                CollectionFieldId = movieStringFieldId2
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId7,
                Value = "Victor Fleming",
                CollectionFieldId = movieStringFieldId1
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = movieItemId7,
                Value = "Adventure, Family, Fantasy",
                CollectionFieldId = movieStringFieldId2
            }
        };

        var movieIntegerField = new List<IntegerField>()
        {
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId1,
                Value = 90,
                CollectionFieldId = movieIntFieldId1,
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId1,
                Value = 175,
                CollectionFieldId = movieIntFieldId3,
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId2,
                Value = 86,
                CollectionFieldId = movieIntFieldId1,
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId2,
                Value = 121,
                CollectionFieldId = movieIntFieldId3,
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId3,
                Value = 89,
                CollectionFieldId = movieIntFieldId1,
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId3,
                Value = 195,
                CollectionFieldId = movieIntFieldId3,
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId4,
                Value = 78,
                CollectionFieldId = movieIntFieldId1,
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId4,
                Value = 195,
                CollectionFieldId = movieIntFieldId3,
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId5,
                Value = 85,
                CollectionFieldId = movieIntFieldId1,
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId5,
                Value = 109,
                CollectionFieldId = movieIntFieldId3,
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId6,
                Value = 83,
                CollectionFieldId = movieIntFieldId1,
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId6,
                Value = 149,
                CollectionFieldId = movieIntFieldId3,
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId7,
                Value = 80,
                CollectionFieldId = movieIntFieldId1,
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId= movieItemId7,
                Value = 102,
                CollectionFieldId = movieIntFieldId3,
            },
        };

        var movieBooleanFields = new List<BooleanField>()
        {
            new BooleanField
            {
                BooleanFieldId = Guid.NewGuid(),
                ItemId= movieItemId1,
                Value = true,
                CollectionFieldId = movieBoolFieldId,
            },
            new BooleanField
            {
                BooleanFieldId = Guid.NewGuid(),
                ItemId= movieItemId2,
                Value = true,
                CollectionFieldId = movieBoolFieldId,
            },
            new BooleanField
            {
                BooleanFieldId = Guid.NewGuid(),
                ItemId= movieItemId3,
                Value = false,
                CollectionFieldId = movieBoolFieldId,
            },
            new BooleanField
            {
                BooleanFieldId = Guid.NewGuid(),
                ItemId= movieItemId4,
                Value = true,
                CollectionFieldId = movieBoolFieldId,
            },
            new BooleanField
            {
                BooleanFieldId = Guid.NewGuid(),
                ItemId= movieItemId5,
                Value = false,
                CollectionFieldId = movieBoolFieldId,
            },
            new BooleanField
            {
                BooleanFieldId = Guid.NewGuid(),
                ItemId= movieItemId6,
                Value = true,
                CollectionFieldId = movieBoolFieldId,
            },
            new BooleanField
            {
                BooleanFieldId = Guid.NewGuid(),
                ItemId= movieItemId7,
                Value = true,
                CollectionFieldId = movieBoolFieldId,
            }
        };

        await dbContext.Collections.AddAsync(movieCollection);
        await dbContext.Items.AddRangeAsync(movieItems);
        await dbContext.CollectionFields.AddRangeAsync(movieCollectionFields);
        await dbContext.IntegerFields.AddRangeAsync(movieIntegerField);
        await dbContext.StringFields.AddRangeAsync(movieStringFields);
        await dbContext.BooleanFields.AddRangeAsync(movieBooleanFields);
        await dbContext.DateFields.AddRangeAsync(movieDateFields);
    }

    private static async Task SeedReligionBooks(AppDbContext dbContext)
    {
        var religionCollectonId = Guid.NewGuid();
        var religionStringFieldId1 = Guid.NewGuid();
        var religionStringFieldId2 = Guid.NewGuid();
        var religionStringFieldId3 = Guid.NewGuid();
        var religionIntFieldId = Guid.NewGuid();
        var religionTextFieldId = Guid.NewGuid();
        var religionItemId1 = Guid.NewGuid();
        var religionItemId2 = Guid.NewGuid();
        var religionItemId3 = Guid.NewGuid();
        var religionItemId4 = Guid.NewGuid();
        var religionItemId5 = Guid.NewGuid();

        var religionCollection = new Collection
        {
            CollectionId = religionCollectonId,
            Name = "The Most Influential Religious Texts",
            CategoryId = 2,
            Description = "This collection features some of the most historically significant religious texts from around the world, revered for their spiritual guidance and impact on various faiths.",
            UserId = _userId2,
            CreationDate = new DateTime(2024, 03, 05)
        };

        var religionCollectionFields = new List<CollectionField>()
        {
            new CollectionField
            {
                CollectionFieldId = religionStringFieldId1,
                CollectionId = religionCollectonId,
                FieldName = "Religion",
                FieldType = FieldType.String,
            },
            new CollectionField
            {
                CollectionFieldId = religionStringFieldId2,
                CollectionId = religionCollectonId,
                FieldName = "Original Language",
                FieldType = FieldType.String,
            },
            new CollectionField
            {
                CollectionFieldId = religionStringFieldId3,
                CollectionId = religionCollectonId,
                FieldName = "First Compiled",
                FieldType = FieldType.String,
            },
            new CollectionField
            {
                CollectionFieldId = religionIntFieldId,
                CollectionId = religionCollectonId,
                FieldName = "Global Followers (thousands of people)",
                FieldType = FieldType.Integer,
            },
            new CollectionField
            {
                CollectionFieldId = religionTextFieldId,
                CollectionId = religionCollectonId,
                FieldName = "Primary Teachings",
                FieldType = FieldType.Text,
            },
        };

        var religionItems = new List<Item>()
        {
            new Item
            {
                ItemId = religionItemId1,
                Name = "The Bible",
                CollectionId = religionCollectonId,
                CreationDate = new DateTime(2024, 03, 06)
            },
            new Item
            {
                ItemId = religionItemId2,
                Name = "The Quran",
                CollectionId = religionCollectonId,
                CreationDate = new DateTime(2024, 03, 06)
            },
            new Item
            {
                ItemId = religionItemId3,
                Name = "The Bhagavad Gita",
                CollectionId = religionCollectonId,
                CreationDate = new DateTime(2024, 04, 18)
            },
            new Item
            {
                ItemId = religionItemId4,
                Name = "The Guru Granth Sahib",
                CollectionId = religionCollectonId,
                CreationDate = new DateTime(2024, 04, 15)
            },
            new Item
            {
                ItemId = religionItemId5,
                Name = "The Torah",
                CollectionId = religionCollectonId,
                CreationDate = new DateTime(2024, 05, 23)
            }
        };

        var religionStringFields = new List<StringField>()
        {
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId1,
                Value = "Christianity",
                CollectionFieldId = religionStringFieldId1
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId2,
                Value = "Islam",
                CollectionFieldId = religionStringFieldId1
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId3,
                Value = "Hinduism",
                CollectionFieldId = religionStringFieldId1
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId4,
                Value = "Sikhism",
                CollectionFieldId = religionStringFieldId1
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId5,
                Value = "Judaism",
                CollectionFieldId = religionStringFieldId1
            },

            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId1,
                Value = "Hebrew, Aramaic, Greek",
                CollectionFieldId = religionStringFieldId2
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId2,
                Value = "Classical Arabic",
                CollectionFieldId = religionStringFieldId2
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId3,
                Value = "Sanskrit",
                CollectionFieldId = religionStringFieldId2
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId4,
                Value = "Gurmukhi",
                CollectionFieldId = religionStringFieldId2
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId5,
                Value = "Hebrew",
                CollectionFieldId = religionStringFieldId2
            },

            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId1,
                Value = "4th Century",
                CollectionFieldId = religionStringFieldId3
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId2,
                Value = "7th Century",
                CollectionFieldId = religionStringFieldId3
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId3,
                Value = "5th-2nd Century BCE",
                CollectionFieldId = religionStringFieldId3
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId4,
                Value = "17th Century",
                CollectionFieldId = religionStringFieldId3
            },
            new StringField
            {
                StringFieldId = Guid.NewGuid(),
                ItemId = religionItemId5,
                Value = "6th-4th Century BCE",
                CollectionFieldId = religionStringFieldId3
            },
        };

        var religionIntFields = new List<IntegerField>()
        {
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId = religionItemId1,
                Value = 2_300_000,
                CollectionFieldId = religionIntFieldId
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId = religionItemId2,
                Value = 1_800_000,
                CollectionFieldId = religionIntFieldId
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId = religionItemId3,
                Value = 1_200_000,
                CollectionFieldId = religionIntFieldId
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId = religionItemId4,
                Value = 30_000,
                CollectionFieldId = religionIntFieldId
            },
            new IntegerField
            {
                IntegerFieldId = Guid.NewGuid(),
                ItemId = religionItemId5,
                Value = 14_000,
                CollectionFieldId = religionIntFieldId
            },
        };

        var religionTextFields = new List<TextField>()
        {
            new TextField
            {
                TextFieldId = Guid.NewGuid(),
                ItemId = religionItemId1,
                Value = "The Bible teaches about God’s creation of the world, the life and teachings of Jesus Christ, and the moral and spiritual guidance for Christians",
                CollectionFieldId = religionTextFieldId
            },
            new TextField
            {
                TextFieldId = Guid.NewGuid(),
                ItemId = religionItemId2,
                Value = "The Quran contains the revelations given to the Prophet Muhammad, outlining the code of conduct for Muslims, including faith, morality, and life after death.",
                CollectionFieldId = religionTextFieldId
            },
            new TextField
            {
                TextFieldId = Guid.NewGuid(),
                ItemId = religionItemId3,
                Value = "The Bhagavad Gita is a 700-verse Hindu scripture that is part of the Indian epic Mahabharata, focusing on the concepts of dharma (duty/righteousness) and yoga (the path to realization and self-discovery).",
                CollectionFieldId = religionTextFieldId
            },
            new TextField
            {
                TextFieldId = Guid.NewGuid(),
                ItemId = religionItemId4,
                Value = "The Guru Granth Sahib is the central religious scripture of Sikhism, regarded by Sikhs as the final, sovereign, and eternal living Guru, following the lineage of the ten human Gurus of the religion.",
                CollectionFieldId = religionTextFieldId
            },
            new TextField
            {
                TextFieldId = Guid.NewGuid(),
                ItemId = religionItemId5,
                Value = "The Torah, also known as the Pentateuch, is the central reference of the religious Judaic tradition, containing the five books of Moses and outlining the history, laws, and ethics of the Jewish people.",
                CollectionFieldId = religionTextFieldId
            },
        };

        await dbContext.Collections.AddAsync(religionCollection);
        await dbContext.Items.AddRangeAsync(religionItems);
        await dbContext.CollectionFields.AddRangeAsync(religionCollectionFields);
        await dbContext.TextFields.AddRangeAsync(religionTextFields);
        await dbContext.IntegerFields.AddRangeAsync(religionIntFields);
        await dbContext.StringFields.AddRangeAsync(religionStringFields);
    }
}

using DataORMLayer.Models;
using DataORMLayer.Models.CustomDataFields;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataORMLayer.EfCoreCode;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Collection> Collections { get; set; }
    public DbSet<CollectionField> CollectionFields { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<StringField> StringFields { get; set; }
    public DbSet<DateField> DateFields { get; set; }
    public DbSet<IntegerField> IntegerFields { get; set; }
    public DbSet<BooleanField> BooleanFields { get; set; }
    public DbSet<TextField> TextFields { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<CollectionField>()
            .Property(e => e.FieldType)
            .HasConversion<string>();
        builder.Entity<Item>()
            .HasMany(e => e.BooleanFields)
            .WithOne(e => e.Item)
            .OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Item>()
            .HasMany(e => e.IntegerFields)
            .WithOne(e => e.Item)
            .OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Item>()
            .HasMany(e => e.TextFields)
            .WithOne(e => e.Item)
            .OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Item>()
            .HasMany(e => e.StringFields)
            .WithOne(e => e.Item)
            .OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Item>()
            .HasMany(e => e.DateFields)
            .WithOne(e => e.Item)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Movies" },
            new Category { CategoryId = 2, Name = "Books" },
            new Category { CategoryId = 3, Name = "Electronic Devices and Gadgets" },
            new Category { CategoryId = 4, Name = "Games, Toys, and Figures" },
            new Category { CategoryId = 5, Name = "Bills and Coins, Stamps" },
            new Category { CategoryId = 6, Name = "Clothes" },
            new Category { CategoryId = 7, Name = "Music Albums, Clips, and Records" },
            new Category { CategoryId = 8, Name = "Cars and Vehicles" },
            new Category { CategoryId = 9, Name = "Dish Recipes" },
            new Category { CategoryId = 10, Name = "Products and Services Reviews" },
            new Category { CategoryId = 11, Name = "Other" }
        );
    }
}
 
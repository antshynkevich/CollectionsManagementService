using DataORMLayer.Models;
using DataORMLayer.Models.CustomDataFields;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace DataORMLayer.EfCoreCode;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Collection> Collections { get; set; }
    public DbSet<CollectionField> CollectionFields { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CollectionField>()
            .Property(e => e.FieldType)
            .HasConversion<string>();

        modelBuilder.Entity<Item>()
            .HasMany(e => e.BooleanFields)
            .WithOne(e => e.Item)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Item>()
            .HasMany(e => e.IntegerFields)
            .WithOne(e => e.Item)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Item>()
            .HasMany(e => e.TextFields)
            .WithOne(e => e.Item)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Item>()
            .HasMany(e => e.StringFields)
            .WithOne(e => e.Item)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Item>()
            .HasMany(e => e.DateFields)
            .WithOne(e => e.Item)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
 
using DataORMLayer.EfCoreCode;
using DataORMLayer.Repository;
using DataORMLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CollectionsManagementService.Services;
using CollectionsManagementService.Services.Interfaces;
using CloudinaryDotNet;
using CollectionsManagementService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorization(options => {
    options.AddPolicy("AdminsOnly", policy => {
        policy.RequireClaim("role", "admin");
        policy.RequireAuthenticatedUser();
    });
    options.AddPolicy("UserNotBlocked", policy => { 
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => !context.User.HasClaim(c => c.Type == "blocked" || c.Value == "blocked"));
    });
});

builder.Services.AddSingleton<ICollectionMapper, CollectionMapper>();
builder.Services.AddSingleton<IItemMapper, ItemMapper>();
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICloudService, CloudService>();
builder.Services.AddScoped<CategoryRepository>();

var cloudinary = new Cloudinary("cloudinary://267417229445433:t2vEgh1RxVe9lqlV7HMqbPmQV1U@dedob71th");
builder.Services.AddSingleton(cloudinary);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>)) as UserManager<ApplicationUser>;
    await ApplicationDbInitializer.SeedUsers(userManager);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

await app.SeedServerWithDataAsync();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

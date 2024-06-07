using DataORMLayer.EfCoreCode;
using DataORMLayer.Repository;
using DataORMLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CollectionsManagementService.Services;
using CollectionsManagementService.Services.Interfaces;
using CloudinaryDotNet;
using CollectionsManagementService;
using CollectionsManagementService.Authorization;
using Microsoft.AspNetCore.Authorization;
using DotNetEnv.Configuration;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddDotNetEnv(".env", LoadOptions.TraversePath());
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

byte[] key = Encoding.UTF8.GetBytes(Env.GetString("tokensecretkey"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("AdminsOnly", policy => {
        policy.RequireClaim("role", "admin");
        policy.RequireAuthenticatedUser();
    });
    options.AddPolicy("UserNotBlocked", policy => { 
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => !context.User.HasClaim(c => c.Type == "blocked" || c.Value == "blocked"));
    });
    options.AddPolicy("CollectionOwnerOrAdminPolicy", policy =>
        policy.Requirements.Add(new MustBeCollectionOwnerOrAdminRequirement()));
});

builder.Services.AddSingleton<ICollectionMapper, CollectionMapper>();
builder.Services.AddSingleton<IItemMapper, ItemMapper>();
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICloudService, CloudService>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddSingleton<IAuthorizationHandler, IsOwnerOrAdminHandler>();
builder.Services.AddScoped<JiraService>();

var cloudinary = new Cloudinary(Env.GetString("CloudinaryLink"));
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

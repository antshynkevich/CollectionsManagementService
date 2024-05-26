using DataORMLayer.EfCoreCode;

namespace CollectionsManagementService;

public static class DbInitializerExtension
{
    public static async Task<IApplicationBuilder> SeedServerWithDataAsync(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            await ApplicationDbInitializer.Initialize(context);
        }
        catch (Exception ex) { }
        return app;
    }
}

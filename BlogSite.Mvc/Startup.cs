using BlogSite.Services.Extensions;

public class Startup
{
    public IConfiguration configRoot
    {
        get;
    }
    public Startup(IConfiguration configuration)
    {
        configRoot = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews().AddRazorRuntimeCompilation();
        services.AddAutoMapper(typeof(Startup));
        services.LoadMyServices();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
            app.UseStatusCodePages();
        }

        app.UseRouting();
        app.UseStaticFiles();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin/{controller=Home/{action=Index}/{id?}"
               );
            endpoints.MapDefaultControllerRoute();
        });

        app.UseHttpsRedirection();
        
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }
}

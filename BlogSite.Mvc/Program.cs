using BlogSite.Mvc.AutoMapper.Profiles;
using BlogSite.Services.AutoMapper.Profiles;
using BlogSite.Services.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)); //adding json resultformat
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
builder.Services.AddSession();
builder.Services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile), typeof(UserProfile));
builder.Services.LoadMyServices();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Admin/User/Login");
    options.LogoutPath = new PathString("/Admin/User/Logout");
    options.Cookie = new CookieBuilder {
        Name = "BlogSite",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest //should always for security
    };
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
    options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied");
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}

app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); //identity
app.UseAuthorization();

app.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );
app.MapDefaultControllerRoute();

//app.MapGet("/", () => "Hello World!");

app.Run();

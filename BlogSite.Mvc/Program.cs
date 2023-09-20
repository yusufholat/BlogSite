
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

////
//it should be? ServiceCollectionExtensions.LoadMyServices(builder.Services);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); //calling configureservices old version

var app = builder.Build();

startup.Configure(app, builder.Environment); //calling configure old version
////

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

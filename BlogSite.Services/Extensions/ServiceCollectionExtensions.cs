using BlogSite.Data.Abstact;
using BlogSite.Data.Concreate;
using BlogSite.Data.Concreate.EntityFramework.Contexts;
using BlogSite.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;


namespace BlogSite.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ProgrammersBlogContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, ICategoryService>();
            serviceCollection.AddScoped<IArticleService, IArticleService>();
            return serviceCollection;
        }
    }
}

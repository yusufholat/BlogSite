using BlogSite.Data.Abstact;
using BlogSite.Data.Concreate;
using BlogSite.Data.Concreate.EntityFramework.Contexts;
using BlogSite.Entities.Concreate;
using BlogSite.Services.Abstract;
using BlogSite.Services.Concreate;
using BlogSite.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;


namespace BlogSite.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ProgrammersBlogContext>();
            serviceCollection.AddIdentity<User,Role>().AddEntityFrameworkStores<ProgrammersBlogContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            return serviceCollection;
        }
    }
}

using BlogSite.Data.Abstact;
using BlogSite.Entities.Concreate;
using BlogSite.Shared.Data.Concreate.EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace BlogSite.Data.Concreate.EntityFramework.Repositories
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}

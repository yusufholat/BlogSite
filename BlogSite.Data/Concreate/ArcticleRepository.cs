using BlogSite.Data.Abstact;
using BlogSite.Entities.Concreate;
using BlogSite.Shared.Data.Concreate.EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace BlogSite.Data.Concreate
{
    public class ArcticleRepository : EfEntityRepositoryBase<Article>, IArcticleRepository
    {
        public ArcticleRepository(DbContext context) : base(context)
        {
            
        }
    }
}

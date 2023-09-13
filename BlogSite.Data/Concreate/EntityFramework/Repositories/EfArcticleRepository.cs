using BlogSite.Data.Abstact;
using BlogSite.Entities.Concreate;
using BlogSite.Shared.Data.Concreate.EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace BlogSite.Data.Concreate
{
    public class EfArcticleRepository : EfEntityRepositoryBase<Article>, IArcticleRepository
    {
        public EfArcticleRepository(DbContext context) : base(context)
        {
            
        }
    }
}

using BlogSite.Data.Abstact;
using BlogSite.Entities.Concreate;
using BlogSite.Shared.Data.Concreate.EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace BlogSite.Data.Concreate.EntityFramework.Repositories
{
    internal class EfRoleRepository : EfEntityRepositoryBase<Role>, IRoleRepository
    {
        public EfRoleRepository(DbContext context) : base(context)
        {
        }
    }
}

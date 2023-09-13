using BlogSite.Data.Abstact;
using BlogSite.Entities.Concreate;
using BlogSite.Shared.Data.Concreate.EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace BlogSite.Data.Concreate
{
    internal class RoleRepository : EfEntityRepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }
    }
}

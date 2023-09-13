using BlogSite.Data.Abstact;
using BlogSite.Entities.Concreate;
using BlogSite.Shared.Data.Concreate.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Data.Concreate
{
    internal class UserRepository : EfEntityRepositoryBase<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}

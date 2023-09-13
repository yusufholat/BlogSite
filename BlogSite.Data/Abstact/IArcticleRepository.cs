using BlogSite.Entities.Concreate;
using BlogSite.Shared.Data.Abstract;

//this interface using for spesific "article" funcs
namespace BlogSite.Data.Abstact
{
    public interface IArcticleRepository : IEntityRepository<Article>
    {

    }
}

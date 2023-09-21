using BlogSite.Entities.Concreate;
using BlogSite.Shared.Entities.Abstract;

namespace BlogSite.Entities.Dtos
{
    public class ArticleListDto : DtoGetBase
    {
        public IList<Article> Articles { get; set; }
    }
}

using BlogSite.Entities.Concreate;
using BlogSite.Shared.Entities.Abstract;


namespace BlogSite.Entities.Dtos
{
    public class ArticleDto : DtoGetBase
    {
        public Article Article { get; set; }

    }
}

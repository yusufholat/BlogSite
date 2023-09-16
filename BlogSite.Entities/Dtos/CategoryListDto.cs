using BlogSite.Entities.Concreate;
using BlogSite.Shared.Entities.Abstract;

namespace BlogSite.Entities.Dtos
{
    public class CategoryListDto : DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}

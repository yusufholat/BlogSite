using BlogSite.Entities.Concreate;
using BlogSite.Shared.Entities.Abstract;


namespace BlogSite.Entities.Dtos
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category { get; set; }
    }
}

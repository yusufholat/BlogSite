using BlogSite.Entities.Concreate;
using BlogSite.Shared.Entities.Abstract;


namespace BlogSite.Entities.Dtos
{
    public class UserDto : DtoGetBase
    {
        public User User { get; set; }
    }
}

using BlogSite.Entities.Concreate;
using BlogSite.Shared.Entities.Abstract;


namespace BlogSite.Entities.Dtos
{
    public class UserListDto : DtoGetBase
    {
        public IList<User>? Users { get; set; }
    }
}

using BlogSite.Entities.Dtos;

namespace BlogSite.Mvc.Areas.Admin.Models
{
    public class UserUpdateAjaxViewModel
    {
        public UserAddDto UserUpdateDto { get; set; }
        public string UserUpdatePartial {  get; set; }
        public UserDto UserDto { get; set; }

    }
}

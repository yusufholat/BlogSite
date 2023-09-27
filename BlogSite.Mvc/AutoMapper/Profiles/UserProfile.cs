using AutoMapper;
using BlogSite.Entities.Concreate;
using BlogSite.Entities.Dtos;


namespace BlogSite.Mvc.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
        }
    }
}

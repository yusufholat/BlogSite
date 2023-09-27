using Microsoft.AspNetCore.Identity;


namespace BlogSite.Entities.Concreate
{
    public class User : IdentityUser<int>
    {
        public string? Picture { get; set; }
        public ICollection<Article>? Articles { get; set; }
    }
}
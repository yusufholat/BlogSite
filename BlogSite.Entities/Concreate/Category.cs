using BlogSite.Shared.Entities.Abstract;


namespace BlogSite.Entities.Concreate
{
    public class Category : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }

    }
}

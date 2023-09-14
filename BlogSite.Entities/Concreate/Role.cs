using BlogSite.Shared.Entities.Abstract;


namespace BlogSite.Entities.Concreate
{
    public class Role : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }

    }
}

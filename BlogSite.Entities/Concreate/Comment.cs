using BlogSite.Shared.Entities.Abstract;


namespace BlogSite.Entities.Concreate
{
    public class Comment : EntityBase, IEntity
    {
        public string Text { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}

using BlogSite.Shared.Entities.Abstract;


namespace BlogSite.Entities.Concreate
{
    public class Comment : EntityBase, IEntity
    {
        public int ArticleId { get; set; }
        public string Text { get; set; }
        public Article Article { get; set; }

    }
}

using BlogSite.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BlogSite.Data.Concreate.EntityFramework.Mappings
{
    //ientitytype using for configure entities
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id); //setting primarykey
            builder.Property(a => a.Id).ValueGeneratedOnAdd(); //using for id increament +
            builder.Property(a => a.Title).HasMaxLength(80);
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(40);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoDescription).HasMaxLength(100);
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(50);
            builder.Property(a => a.ViewsCount).IsRequired();
            builder.Property(a => a.CommentCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);

            //from entitybase
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);

            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId); //setting 1-many connection between article&category
            //it means category has more than one article, article has one category
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);

            builder.ToTable("Articles");

        }
    }
}

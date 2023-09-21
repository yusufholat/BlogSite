using BlogSite.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BlogSite.Data.Concreate.EntityFramework.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd(); //auto increment
            builder.Property(c =>c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(60);
            builder.Property(c => c.Description).HasMaxLength(100);

            //from entitybase
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500);

            builder.ToTable("Categories");
            //this entity not need to other entities, currently not have any other entity id's

            //adding 3 new category data
            builder.HasData(
                new Category{
                    Id = 1,
                    Name = "C#",
                    Description = "C# programlama dili",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C# blog kategorisi",
                }, 
                new Category
                {
                    Id = 2,
                    Name = "C++",
                    Description = "C++ programlama dili",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ blog kategorisi",
                },
                new Category
                {
                    Id = 3,
                    Name = "Java",
                    Description = "Java programlama dili",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Java blog kategorisi",
                });
        }
    }
}

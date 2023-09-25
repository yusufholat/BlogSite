using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BlogSite.Entities.Dtos
{
    public class CategoryAddDto
    {

        [DisplayName("Kategori Adi")] //using for display
        [Required(ErrorMessage ="{0} adi bos gecilemez")]
        [MaxLength(70, ErrorMessage = "{0} {1} den buyuk olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} den kucuk olamaz")]
        public required string Name { get; set; }
                [DisplayName("Kategori Aciklamasi")] //using for display
        [MaxLength(500, ErrorMessage = "{0} {1} den buyuk olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} den kucuk olamaz")]
        public string? Description { get; set; }

        [DisplayName("Kategori Ozel Not Alani")] //using for display
        [MaxLength(500, ErrorMessage = "{0} {1} den buyuk olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} den kucuk olamaz")]
        public string? Note { get; set; }

        [DisplayName("Aktif Mi")] //using for display
        [Required(ErrorMessage = "{0} bos gecilemez")]
        public bool IsActive { get; set; }

        [DisplayName("Silindi Mi")] //using for display
        [Required(ErrorMessage = "{0} bos gecilemez")]
        public bool IsDeleted { get; set; }

    }
}

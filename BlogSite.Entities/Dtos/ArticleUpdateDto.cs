using BlogSite.Entities.Concreate;
using BlogSite.Shared.Entities.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BlogSite.Entities.Dtos
{
    public class ArticleUpdateDto : DtoGetBase
    {
        [Required()]
        public int Id { get; set; }

        [DisplayName("Baslik")] //using for display
        [Required(ErrorMessage = "{0} baslik bos gecilemez")]
        [MaxLength(100, ErrorMessage = "{0} {1} den buyuk olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} den kucuk olamaz")]
        public string Title { get; set; }

        [DisplayName("Icerik")] //using for display
        [Required(ErrorMessage = "{0} iceik bos gecilemez")]
        [MinLength(3, ErrorMessage = "{0} {1} den kucuk olamaz")]
        public string Content { get; set; }

        [DisplayName("Thumbnail")] //using for display
        [Required(ErrorMessage = "{0} baslik bos gecilemez")]
        [MaxLength(250, ErrorMessage = "{0} {1} den buyuk olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} den kucuk olamaz")]
        public string Thumbnail { get; set; }

        [DisplayName("Tarih")] //using for display
        [Required(ErrorMessage = "{0} tarih bos gecilemez")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Seo Aciklama")] //using for display
        [Required(ErrorMessage = "{0} baslik bos gecilemez")]
        [MaxLength(50, ErrorMessage = "{0} {1} den buyuk olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} den kucuk olamaz")]
        public string SeoAutor { get; set; }

        [DisplayName("Seo Etiketler")] //using for display
        [Required(ErrorMessage = "{0} baslik bos gecilemez")]
        [MaxLength(50, ErrorMessage = "{0} {1} den buyuk olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} den kucuk olamaz")]
        public string SeoTags { get; set; }

        [DisplayName("Kategori")] //using for display
        [Required(ErrorMessage = "{0} baslik bos gecilemez")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DisplayName("silinsin mi")] //using for display
        [Required(ErrorMessage = "{0} baslik bos gecilemez")]
        public bool IsDeleted { get; set; }

        [DisplayName("aktif mi")] //using for display
        [Required(ErrorMessage = "{0} baslik bos gecilemez")]
        public bool IsActive { get; set; }

    }
}

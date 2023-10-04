using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BlogSite.Entities.Dtos
{
    public class UserUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Kullanici Adi")] //using for display
        [Required(ErrorMessage = "{0} adi bos gecilemez")]
        [MaxLength(50, ErrorMessage = "{0} {1} den buyuk olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} den kucuk olamaz")]
        public string? UserName { get; set; }

        [DisplayName("Eposta Adresi")] //using for display
        [Required(ErrorMessage = "{0} adi bos gecilemez")]
        [MaxLength(100, ErrorMessage = "{0} {1} den buyuk olamaz")]
        [MinLength(10, ErrorMessage = "{0} {1} den kucuk olamaz")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DisplayName("Telefon No")] //using for display
        [Required(ErrorMessage = "{0} adi bos gecilemez")]
        [MaxLength(13, ErrorMessage = "{0} {1} den buyuk olamaz")] //tr number
        [MinLength(13, ErrorMessage = "{0} {1} den kucuk olamaz")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [DisplayName("Resim Ekle")] //using for display
        [DataType(DataType.Upload)]
        public IFormFile? PictureFile { get; set; }

        [DisplayName("Resim")] //using for display
        public string? Picture { get; set; }

    }
}

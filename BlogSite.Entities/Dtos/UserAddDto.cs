using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BlogSite.Entities.Dtos
{
    public class UserAddDto
    {
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

        [DisplayName("Sifre")] //using for display
        [Required(ErrorMessage = "{0} adi bos gecilemez")]
        [MaxLength(30, ErrorMessage = "{0} {1} den buyuk olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} den kucuk olamaz")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DisplayName("Telefon No")] //using for display
        [Required(ErrorMessage = "{0} adi bos gecilemez")]
        [MaxLength(13, ErrorMessage = "{0} {1} den buyuk olamaz")] //tr number
        [MinLength(13, ErrorMessage = "{0} {1} den kucuk olamaz")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [DisplayName("Resim")] //using for display
        [Required(ErrorMessage = "bir resim {0} seciniz")]
        [DataType(DataType.Upload)]
        public IFormFile? Picture { get; set; }

    }
}

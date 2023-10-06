using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace BlogSite.Entities.Dtos
{
    public class UserLoginDto
    {
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

        [DisplayName("Beni Hatirla")]
        public bool RememberMe {  get; set; }
    }
}

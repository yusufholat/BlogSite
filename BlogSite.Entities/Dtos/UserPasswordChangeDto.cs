using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Dtos
{
    public class UserPasswordChangeDto
    {
        [DisplayName("Su anki sifreniz")] //using for display
        [Required(ErrorMessage = "{0} adi bos gecilemez")]
        [MaxLength(30, ErrorMessage = "{0} {1} den buyuk olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} den kucuk olamaz")]
        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }

        [DisplayName("yeni sifreniz")] //using for display
        [Required(ErrorMessage = "{0} adi bos gecilemez")]
        [MaxLength(30, ErrorMessage = "{0} {1} den buyuk olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} den kucuk olamaz")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [DisplayName("Su anki sifreniz")] //using for display
        [Required(ErrorMessage = "{0} adi bos gecilemez")]
        [MaxLength(30, ErrorMessage = "{0} {1} den buyuk olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} den kucuk olamaz")]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage ="girmis oldugunuz yeni sifreler ayni degildir")]
        public string? RepeatPassword { get; set; }
    }
}

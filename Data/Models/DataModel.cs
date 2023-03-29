using ApplicationMember.Data.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationMember.Data.Models
{
    public class DataModel : BaseModel
    {
        [Required]
        [StringLength(16)]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Please enter a valid 16 digit NIK")]
        [Column("nik")]
        public string NIK { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("phone")]
        [StringLength(14, MinimumLength = 10, ErrorMessage = "Please enter a phone number between 10 and 14 digits")]
        [RegularExpression(@"^\d{10,14}$", ErrorMessage = "Please enter a phone number with 10 to 14 numeric characters only")]
        public string Phone { get; set; }

        [Column("image_path")]
        public string Path { get; set; }
    }
}

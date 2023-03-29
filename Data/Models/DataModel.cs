using ApplicationMember.Data.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationMember.Data.Models
{
    public class DataModel : BaseModel
    {
        [Required]
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
        public string Phone { get; set; }

        [Column("image_path")]
        public string Path { get; set; }
    }
}

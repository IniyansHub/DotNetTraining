using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CRUD_App.Models
{
    public class AdhaarModel
    {
        [Key]
        public int AdhaarNumber { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Please Enter Name.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        public int Age { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? Address { get; set; }

    }
}

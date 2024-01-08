using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IdentityLoginSignUp.Areas.Identity.Data
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Student Name", TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Standard { get; set; }

        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
    }
}

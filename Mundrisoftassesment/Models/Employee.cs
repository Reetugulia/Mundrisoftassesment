using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mundrisoftassesment.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string? City { get; set; }
        public int? DepartmentId { get; set;}

    }
}

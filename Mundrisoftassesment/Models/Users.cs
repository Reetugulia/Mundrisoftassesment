using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mundrisoftassesment.Models
{
    public enum Role { Admin = 1, Customer };
    [Table("Users")]
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public string? EmailId { get; set; }
        [Required]
        [DataType(DataType.Password)]
		
		public string? Password { get; set; }
        
        [NotMapped]
        [Compare("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
        public int RoleId { get; set; }
      

    }
}

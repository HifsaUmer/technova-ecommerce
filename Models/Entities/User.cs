using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace technova_ecommerce.Models.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }
        [Column("user_name")]
    
        public string UserName { get; set; }
        [Column("hashed_password")]
        public string hashed_password { get; set; }
        [Column("role")]
        public string? Role { get; set; }
      
    }
}

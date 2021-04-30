using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        
        [Column(TypeName="varchar(50)")]
        [Required]
        public string Name { get; set; }
        
        [Column(TypeName="varchar(50)")]
        public string Address { get; set; }
        
        [Column(TypeName="varchar(20)")]
        [Required]
        public string Contact { get; set; }
    }
}
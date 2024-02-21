using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace account_service.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string email { get; set; }
    }
}

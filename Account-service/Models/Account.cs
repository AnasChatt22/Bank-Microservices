using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace account_service.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string accountId { get; set; }
        [Required]
        public double balance { get; set; }
        [Required]
        public DateTime createdAt { get; set; }
        [Required]
        public string currency { get; set; }
        [Required]
        public string accountType { get; set; }
        public Customer customer { get; set; }
        [Required]
        public long customerId { get; set; }
    }
}

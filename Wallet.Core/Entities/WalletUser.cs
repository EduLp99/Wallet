using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletProject.Core.Entities
{
    public class WalletUser
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }
        public string Bank { get; set; }
        public DateTime LastUpdated { get; set; }
        public User User { get; set; }
    }
}

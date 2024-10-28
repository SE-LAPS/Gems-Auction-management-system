using backend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Dto.Bid
{
    public class PlaceBidDto
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [Required]
        [ForeignKey("Auction")]
        public int AuctionId { get; set; }

    }
}

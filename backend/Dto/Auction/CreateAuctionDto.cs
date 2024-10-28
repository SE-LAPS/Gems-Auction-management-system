using backend.Models;
using System.ComponentModel.DataAnnotations;

namespace backend.Dto.Auction
{
    public class CreateAuctionDto
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        [Required]
        public int ArtId { get; set; }
    }
}

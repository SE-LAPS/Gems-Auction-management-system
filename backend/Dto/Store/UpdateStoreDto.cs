using System.ComponentModel.DataAnnotations;

namespace backend.Dto.Store
{
    public class UpdateStoreDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber {  get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string CoverPhoto {  get; set; } = string.Empty;
        [Required]
        public string ProfilePhoto {  get; set; } = string.Empty;
    }
}

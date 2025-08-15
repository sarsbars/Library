using System.ComponentModel.DataAnnotations;

namespace Library.Models {
    public class LocationViewModel {
        public int LocationID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Location name cannot exceed 100 characters.")]
        public string LocationName { get; set; } // String for custom input

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}
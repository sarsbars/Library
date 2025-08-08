using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models {
    public enum RoleType {
        Admin,
        Staff,
        Reader
    }

    public enum GenderType {
        Male,
        Female,
        NonBinary,
        PreferNotToDisclose
    }

    public class User {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public RoleType Role { get; set; }

        [Required]
        public GenderType Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
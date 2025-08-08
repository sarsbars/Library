using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models {
    public enum LocationNameType {
        BoyeOgundiyaAcademicLibrary,
        HallResearchCenter,
        HuaKnowledgeInstitute,
        MitchellLearningCommons,
        SolomonMemorialLibrary
    }
    public class Location {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        [Required]
        public LocationNameType LocationName { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
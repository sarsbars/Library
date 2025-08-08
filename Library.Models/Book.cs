using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models {
    public enum ConditionType {
        Mint,
        New,
        Used,
        Damaged
    }

    public enum GenreType {
        Fiction,
        NonFiction,
        ScienceFiction,
        Mystery,
        Romance,
        Fantasy,
        Childrens,
        Humour,
        Technology,
        Science,
        Textbooks,
        GraphicNovel,
        Magazine,
        Manga
    }

    public class Book {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }

        [Required]
        [ForeignKey("Location")]
        public int LocationID { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public GenreType Genre { get; set; }

        [Required]
        public ConditionType Condition { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public int LocationInLibrary { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
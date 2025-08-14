using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models {
    public enum LoanStatusType {
        TakenOut,
        Returned,
        Overdue,
        OnHold
    }

    public class Loan {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanID { get; set; }

        [Required]
        [ForeignKey("Location")]
        public int LocationID { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int BookID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public DateTime DateBorrowed { get; set; }

        [Required]
        public LoanStatusType LoanStatus { get; set; }

        public virtual Location? Location { get; set; }
        public virtual Book? Book { get; set; }
        public virtual User? User { get; set; }
    }
}

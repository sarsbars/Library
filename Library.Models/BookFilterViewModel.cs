using System.ComponentModel.DataAnnotations;

namespace Library.Models {
    public class BookFilterViewModel {
        public string? Author { get; set; }
        public LocationNameType? Location { get; set; }
        public GenreType? Genre { get; set; }
        public ConditionType? Condition { get; set; }
        public bool? IsAvailable { get; set; }
        [Required]
        public List<Book> Books { get; set; }
    }
}

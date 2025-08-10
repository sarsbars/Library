namespace Library.Models {
    public class BookFilterViewModel {
        public string? Author { get; set; }
        public int? LocationID { get; set; }
        public LocationNameType? Location { get; set; }
        public GenreType? Genre { get; set; }
        public ConditionType? Condition { get; set; }
        public bool? IsAvailable { get; set; }
        public List<Book> Books { get; set; }
    }
}

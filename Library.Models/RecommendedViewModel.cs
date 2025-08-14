namespace Library.Models {
    public class RecommendedViewModel {
        public User User { get; set; }
        public List<GenreType>? Genres { get; set; }
        public List<string>? Authors { get; set; }
        public Dictionary<GenreType, List<Book>>? GenreBooks { get; set; }
        public Dictionary<string, List<Book>>? AuthorBooks { get; set; }
        public List<Loan>? Loans { get; set; }
    }
}

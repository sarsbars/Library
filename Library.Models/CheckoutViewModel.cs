using Library.Models;

namespace Library.ViewModels {
    public class CheckoutViewModel {
        public List<Loan> Holds { get; set; } = new List<Loan>();
        public List<Loan> CurrentLoans { get; set; } = new List<Loan>();
        public List<Book> RecentBooks { get; set; } = new List<Book>();
    }
}

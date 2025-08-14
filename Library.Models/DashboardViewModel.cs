using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models {
    public class DashboardViewModel {
        public int TotalBooks { get; set; }
        public int TotalUsers {get; set;}
        public int TotalLoans { get; set; }
        public int OverDueBooksCount { get; set; }
        public ICollection<Book> MostRecentlyAddedBooks { get; set; }
        public ICollection<Book> AvailableBooks { get; set; }
        public ICollection<User> TopBorrowers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models {
    public class CheckoutDashboardViewModel {
        public List<Book> CurrentLoans { get; set; }
        public List<Book> PendingHolds { get; set; }
        public List<Book> RecentBooks { get; set; }
    }
}

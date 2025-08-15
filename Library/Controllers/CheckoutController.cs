using Library.DAL;
using Library.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library.Controllers {
    public class CheckoutController : Controller {
        private readonly LibraryDBContext _context;

        public CheckoutController(LibraryDBContext context) {
            _context = context;
        }

        public IActionResult Index() {
            var model = new CheckoutViewModel {               
                Holds = _context.Loans
                    .Include(l => l.Book)
                    .Include(l => l.User)
                    .Include(l => l.Location)
                    .Where(l => l.LoanStatus == LoanStatusType.OnHold)
                    .OrderByDescending(l => l.DateBorrowed)
                    .ToList(),
             
                CurrentLoans = _context.Loans
                    .Include(l => l.Book)
                    .Include(l => l.User)
                    .Include(l => l.Location)
                    .Where(l => l.LoanStatus == LoanStatusType.TakenOut)
                    .OrderByDescending(l => l.DateBorrowed)
                    .ToList(),

                RecentBooks = _context.Books
                    .OrderByDescending(b => b.BookID) 
                    .Take(5)
                    .ToList()
            };

            return View(model);
        }
    }
}

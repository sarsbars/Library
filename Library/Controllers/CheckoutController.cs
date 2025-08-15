using Library.BLL;
using Library.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Library.Controllers {
    public class CheckoutController : Controller {
        private readonly UserService _userService;
        private readonly LoanService _loanService;
        private readonly BookService _bookService;

        public CheckoutController(UserService userService, LoanService loanService, BookService bookService) {
            _userService = userService;
            _loanService = loanService;
            _bookService = bookService;
        }

        [Authorize]
        public IActionResult Index() {
            string email = User?.Identity?.Name;

            if (string.IsNullOrEmpty(email)) {
                return RedirectToAction("Login", "Account");
            }

            User currentUser = _userService.GetCurrentUser(email);

            List<Loan> holds = new List<Loan>();
            List<Loan> currentLoans = new List<Loan>();

            if (currentUser != null) {
                RoleType role = currentUser.Role;

                if (role == RoleType.Reader) {
                    holds = currentUser.Loans
                        .Where(l => l.LoanStatus == LoanStatusType.OnHold)
                        .ToList();

                    currentLoans = currentUser.Loans
                        .Where(l => l.LoanStatus == LoanStatusType.TakenOut || l.LoanStatus == LoanStatusType.Overdue)
                        .ToList();
                } else {
                    holds = _loanService.GetAllHolds();
                    currentLoans = _loanService.GetAllCurrentLoans();
                }
            }

                List<Book> recentBooks = _bookService.GetMostRecentBooks(5);

            var viewModel = new CheckoutViewModel {
                Holds = holds,
                CurrentLoans = currentLoans,
                RecentBooks = recentBooks
            };

            return View(viewModel);
        }
    }
}

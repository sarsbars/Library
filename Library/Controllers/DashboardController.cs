using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers {
    public class DashboardController : Controller {
        private readonly UserService _userService;
        private readonly LoanService _loanService;
        private readonly LocationService _locationService;
        private readonly BookService _bookService;

        public DashboardController(
            UserService userService,
            LoanService loanService,
            LocationService locationService,
            BookService bookService) {
            _userService = userService;
            _loanService = loanService;
            _locationService = locationService;
            _bookService = bookService;
        }
        public IActionResult Index() {
            DashboardViewModel model = new DashboardViewModel {
                TotalBooks = _bookService.GetTotalBooks(),
                TotalUsers = _userService.GetTotalUsers(),
                TotalLoans = _loanService.GetTotalLoans(),
                OverDueBooksCount = _loanService.GetOverdueBooksCount(),
                AvailableBooks = _bookService.GetAvailableBooks(),
                TopBorrowers = _userService.GetTopBorrowers(),
                LocationWithMostBorrows = _locationService.GetLocationWithMostBorrows()
            };

            return View(model);
        }
    }
}

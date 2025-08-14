using Library.BLL;
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
            return View();
        }
    }
}

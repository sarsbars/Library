using Library.BLL;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers {
    public class CheckoutController : Controller {
        private readonly HoldService _holdService;
        private readonly LoanService _loanService;
        private readonly BookService _bookService;

        public CheckoutController(
            HoldService holdService,
            LoanService loanService,
            BookService bookService) {
            _holdService = holdService;
            _loanService = loanService;
            _bookService = bookService;
        }

        public IActionResult Index() {
            var model = new CheckoutViewModel {
                HoldsWaitingPickup = _holdService.GetHoldsWaitingForPickup(),
                CurrentLoans = _loanService.GetCurrentLoans(),
                RecentBooks = _bookService.GetMostRecentBooks(5)
            };

            return View(model);
        }
    }
}

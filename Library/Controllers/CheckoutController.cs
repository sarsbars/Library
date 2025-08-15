using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers {
    [Authorize]
    public class CheckoutController : Controller {
        private readonly CheckoutService _checkoutService;

        public CheckoutController(CheckoutService checkoutService) {
            _checkoutService = checkoutService;
        }

        public IActionResult Dashboard() {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var viewModel = new CheckoutDashboardViewModel {
                CurrentLoans = _checkoutService.GetCurrentLoans(userId),
                PendingHolds = _checkoutService.GetPendingHolds(userId),
                RecentBooks = _checkoutService.GetRecentBooks(userId, 5)
            };

            return View("Checkout", viewModel);
        }

        [HttpPost]
        public IActionResult RenewLoan(int id) {
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult CancelHold(int id) {
            return RedirectToAction("Dashboard");
        }

        public IActionResult FullHistory() {
            return View();
        }
    }

}

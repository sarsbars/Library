using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers {
    public class DashboardController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}

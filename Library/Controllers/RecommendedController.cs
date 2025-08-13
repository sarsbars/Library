using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers {
    public class RecommendedController : Controller {
        public IActionResult Recommended () {
            return View();
        }
    }
}

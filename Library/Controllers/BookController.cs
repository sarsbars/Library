using Library.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers {
    public class BookController : Controller {
        private readonly BookService _bookService;
        public BookController (BookService bookService) {
            _bookService = bookService;
        }
        public IActionResult Index () {
            return View();
        }
    }
}

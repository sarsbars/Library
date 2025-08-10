using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers {
    public class BookController : Controller {
        private readonly BookService _bookService;
        public BookController (BookService bookService) {
            _bookService = bookService;
        }

        public IActionResult Index () {
            List<Book> books = _bookService.GetBooks();
            return View(books);
        }

        [HttpGet]
        [Route("Books/Details/{BookID}")]
        public IActionResult Details(int BookID) {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int BookID) {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Book book) {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int BookID) {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int BookID) {
            return RedirectToAction("Index");
        }
    }
}

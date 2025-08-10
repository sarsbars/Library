using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers {
    public class BookController : Controller {
        private readonly BookService _bookService;
        public BookController (BookService bookService) {
            _bookService = bookService;
        }

        public IActionResult Index () {
            List<Book> books = _bookService.GetBooks();

            List<string> authors = _bookService.GetBooks()
                .Select(b => b.Author)
                .Where(a => !string.IsNullOrEmpty(a))
                .Distinct()
                .OrderBy(a => a)
                .ToList();

            ViewBag.Authors = new SelectList(authors);

            return View(new BookFilterViewModel {
                Books = books
            });
        }

        [HttpPost]
        public IActionResult FilterBooks(BookFilterViewModel filters) {
            List<Book> filteredBooks = _bookService.GetBooks().Where(b =>
                (!filters.Genre.HasValue || b.Genre == filters.Genre) &&
                (!filters.Condition.HasValue || b.Condition == filters.Condition) &&
                (string.IsNullOrEmpty(filters.Author) || b.Author == filters.Author) &&
                (!filters.Location.HasValue || b.Location.LocationName == filters.Location))
                .ToList();

            List<string> authors = _bookService.GetBooks()
                .Select(b => b.Author)
                .Where(a => !string.IsNullOrEmpty(a))
                .Distinct()
                .OrderBy(a => a)
                .ToList();

            ViewBag.Authors = new SelectList(authors);

            filters.Books = filteredBooks;
            return View("Index", filters);
        }

        public IActionResult ClearFilters() {
            List<Book> books = _bookService.GetBooks();
            return View(new BookFilterViewModel {
                Books = books
            });
        }

        [HttpGet]
        [Route("Books/Details/{BookID}")]
        public IActionResult Details(int BookID) {
            Book book = _bookService.GetBookByID(BookID);
            if(book == null) {
                return NotFound();
            }
            return View(book);
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

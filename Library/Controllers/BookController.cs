using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace Library.Controllers {

    [Authorize]
    public class BookController : Controller {
        private readonly BookService _bookService;
        private readonly LocationService _locationService;
        public BookController (BookService bookService, LocationService locationService) {
            _bookService = bookService;
            _locationService = locationService;
        }
        [AllowAnonymous]
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
                (!filters.Location.HasValue || b.Location.LocationName == filters.Location) &&
                (!filters.IsAvailable.HasValue || b.IsAvailable == filters.IsAvailable))
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
            Book book = _bookService.GetBooks().FirstOrDefault(b => b.BookID == BookID);
            if(book == null ) {
                return NotFound();
            }
            ViewBag.BookLocation = book.Location.LocationName;
            return View(book);
        }

        [Authorize(Roles = "Staff, Admin")]
        [HttpGet]
        public IActionResult Create() {
            List<Location> locations = _locationService.GetLocations();
            ViewBag.Locations = locations;
            return View();
        }

        [Authorize(Roles = "Staff, Admin")]
        [HttpPost]
        public IActionResult Create(Book book) {
            ModelState.Remove(nameof(book.Location));

            if(!ModelState.IsValid) {
                List<Location> locations = _locationService.GetLocations();
                ViewBag.Locations = locations;

                return View(book);
            }

            Location assignedLocation = _locationService.GetLocations().FirstOrDefault(l => l.LocationID == book.LocationID);
            book.Location = assignedLocation;

            _bookService.AddBook(book);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Staff, Admin")]
        [HttpGet]
        public IActionResult Update(int BookID) {
            Book book = _bookService.GetBookByID(BookID);
            if(book == null) {
                return NotFound();
            }
            
            ViewBag.Locations = _locationService.GetLocations();

            return View(book);
        }

        [Authorize(Roles = "Staff, Admin")]
        [HttpPost]
        public IActionResult Update(Book newBook) {
            ModelState.Remove(nameof(newBook.Location));

            if (!ModelState.IsValid) {
                ViewBag.Locations = _locationService.GetLocations();
                return View(newBook);
            }

            _bookService.UpdateBook(newBook);

            Book oldBook = _bookService.GetBookByID(newBook.BookID);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Staff, Admin")]
        [HttpGet]
        public IActionResult Delete(int BookID) {
            Book book = _bookService.GetBooks().FirstOrDefault(b => b.BookID == BookID);
            if (book == null) {
                return NotFound();
            }
            ViewBag.BookLocation = book.Location.LocationName;
            return View(book);
        }

        [Authorize(Roles = "Staff, Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int BookID) {
            Book book = _bookService.GetBooks().FirstOrDefault(b => b.BookID == BookID);
            if (book == null) {
                return NotFound();
            }

            _bookService.DeleteBook(book);

            return RedirectToAction("Index");
        }
    }
}

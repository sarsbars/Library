using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace Library.Controllers {
    public class BookController : Controller {
        private readonly BookService _bookService;
        private readonly LocationService _locationService;
        public BookController (BookService bookService, LocationService locationService) {
            _bookService = bookService;
            _locationService = locationService;
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

        [HttpGet]
        public IActionResult Create() {
            List<Location> locations = _locationService.GetLocations();
            ViewBag.Locations = locations;
            return View();
        }

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
            //_locationService.AddBook(book, assignedLocation);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int BookID) {
            Book book = _bookService.GetBookByID(BookID);
            if(book == null) {
                return NotFound();
            }
            
            ViewBag.Locations = _locationService.GetLocations();

            return View(book);
        }

        [HttpPost]
        public IActionResult Update(Book newBook) {
            ModelState.Remove(nameof(newBook.Location));

            if (!ModelState.IsValid) {
                ViewBag.Locations = _locationService.GetLocations();
                return View(newBook);
            }

            _bookService.UpdateBook(newBook);

            Book oldBook = _bookService.GetBookByID(newBook.BookID);

            //I'm not sure if these are needed, everything works fine without them but I'm gonna leave them just in case - Connor

            //Location? oldLocation = _locationService.GetLocationByID(oldBook.LocationID);
            //Location? newLocation = _locationService.GetLocationByID(newBook.LocationID);
            

            //if(oldLocation.LocationID != newLocation.LocationID) {
            //    _locationService.RemoveBook(newBook, oldLocation);
            //    _locationService.AddBook(newBook, newLocation);
            //}

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int BookID) {
            Book book = _bookService.GetBooks().FirstOrDefault(b => b.BookID == BookID);
            if (book == null) {
                return NotFound();
            }
            ViewBag.BookLocation = book.Location.LocationName;
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int BookID) {
            Book book = _bookService.GetBooks().FirstOrDefault(b => b.BookID == BookID);
            if (book == null) {
                return NotFound();
            }

            //_locationService.RemoveBook(book, book.Location);
            _bookService.DeleteBook(book);

            return RedirectToAction("Index");
        }
    }
}

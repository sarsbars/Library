using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Controllers {
    public class LoanController : Controller {
        private readonly LoanService _loanService;
        private readonly LocationService _locationService;
        private readonly BookService _bookService;
        private readonly UserService _userService;

        public LoanController(LoanService loanService ,LocationService locationService, BookService bookService) {
            _loanService = loanService;
            _locationService = locationService;
            _bookService = bookService;
        }
        public IActionResult Index() {
            IEnumerable<Loan> loans;
            if (User.IsInRole("Admin")) {
                loans = _loanService.GetLoans();
                books = _bookService.GetBooks();

            } else {
                string userId = User.Identity.Name;
                loans = _loanService.GetLoans();
            }
                return View(loans);
        }

        [HttpGet]
        public IActionResult Create() {
            List<Location> locations = _locationService.GetLocations();
            ViewBag.LocationList = new SelectList(locations, "LocationID", "LocationName");

            List<Book> books = _bookService.GetBooks();
            List<Book> availableBooks = books.Where(b => b.IsAvailable == true).ToList();
            List<SelectListItem> bookDisplayList = availableBooks.Select(b => new SelectListItem {
                Value = b.BookID.ToString(),
                Text = $"{b.Title} by {b.Author} - {b.Condition} ({b.Genre}) [ID: {b.BookID}]",
            }).ToList();
            ViewBag.BookList = bookDisplayList;

            List<User> users = _userService.GetUsers();
            List<User> availableUsers = users.Where(b => b.IsAvailable == true).ToList();
            List<SelectListItem> userDisplayList = availableUsers.Select(b => new SelectListItem {
                Value = u.UserID.ToString(),
                Text = $"{U.Name} - ID: {u.UserID}"
            }).ToList();
            ViewBag.UserList = userDisplayList;
            return View(new Loan());
        }

        [HttpPost]
        public IActionResult Create(Loan loan) {
            if(!ModelState.IsValid) {
                List<Location> locations = _locationService.GetLocations();
                ViewBag.LocationList = new SelectList(locations, "LocationID", "LocationName", loan.LocationID);

                List<Book> books = _bookService.GetBooks();
                List<Book> availableBooks = books.Where(b => b.IsAvailable == true).ToList();
                List<SelectListItem> bookDisplayList = availableBooks.Select(b => new SelectListItem {
                    Value = b.BookID.ToString(),
                    Text = $"{b.Title} by {b.Author} - {b.Condition} ({b.Genre}) [ID: {b.BookID}]",
                    Selected = b.BookID == loan.BookID
                }).ToList();
                ViewBag.BookList = bookDisplayList;

                List<User> users = _userService.GetUsers();
                List<User> availableUsers = users.Where(b => b.IsAvailable == true).ToList();
                List<SelectListItem> userDisplayList = availableUsers.Select(b => new SelectListItem {
                    Value = u.UserID.ToString(),
                    Text = $"{U.Name} - ID: {u.UserID}"
                }).ToList();
                ViewBag.UserList = userDisplayList;
                return View(loan);
            }
            List<SelectedItem> book = _bookService.GetBookByID(loan.BookID);
            if (book != null) {
                book.IsAvailable = false;
                _bookService.UpdateBook(book);
            }

            _loanService.AddLoan(loan);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id) {
            Loan loan = _loanService.GetLoans().FirstOrDefault(l => l.LoanID == id);
            if(loan == null) {
                return NotFound();
            }
            return View(loan);
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            Loan loan = _loanService.GetLoanById(id);
            if (loan == null) {
                return NotFound();
            }
            List<Location> locations = _locationService.GetLocations();
            ViewBag.LocationList = new SelectList(locations, "LocationID", "LocationName", loan.LocationID);

            List<Book> books = _bookService.GetBooks();
            ViewBag.BookList = new SelectList(books, "BookID", "Title", loan.BookID);

            List<User> users = _userService.GetUsers();
            ViewBag.UserList = new SelectList(users, "UserID", "Name", loan.UserID);
            return View(loan);
        }

        [HttpPost]
        public IActionResult Edit(Loan loan) {
            if (!ModelState.IsValid) {
                List<Location> locations = _locationService.GetLocations();
                ViewData["LocationList"] = new SelectList(locations, "LocationID", "LocationName", loan.LocationID);

                List<Book> books = _bookService.GetBooks();
                ViewBag.BookList = new SelectList(books, "BookID", "Title", loan.BookID);

                List<User> users = _userService.GetUsers();
                ViewBag.UserList = new SelectList(users, "UserID", "Name", loan.UserID);
                return View(loan);
            }
            _loanService.UpdateLoan(loan);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            Loan loan = _loanService.GetLoanById(id);
            if (loan == null) {
                return NotFound();
            }
            return View(loan);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id) {
            _loanService.DeleteLoan(id);
            return RedirectToAction("Index");
        }
    }
}

using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Controllers {
    public class LoanController : Controller {
        private readonly LoanService _loanService;
        private readonly LocationService _locationService;
        private readonly BookService _bookService;
        private readonly UserService _userService;

        public LoanController(LoanService loanService, LocationService locationService, BookService bookService, UserService userService) {
            _loanService = loanService;
            _locationService = locationService;
            _bookService = bookService;
            _userService = userService;
        }

        [Authorize]
        public IActionResult Index() {
            IEnumerable<Loan> loans = _loanService.GetLoans();

            if (User.IsInRole("Admin") || User.IsInRole("Staff" )) {
                loans = _loanService.GetLoans();
            }
            else {
                var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
                if (string.IsNullOrEmpty(userEmail)) {
                    return Unauthorized("User email not found");
                }

                var user = _userService.GetAllUsers().FirstOrDefault(u => u.Email == userEmail);
                if (user == null) {
                    return BadRequest("User not found in system");
                }

                loans = _loanService.GetLoans().Where(l => l.UserID == user.UserID);
            }
            loans = loans.OrderByDescending(l => l.LoanID);
            return View(loans);
        }

        [Authorize]
        [Authorize(Roles = "Admin, Staff")]
        [HttpGet]
        public IActionResult Create() {
            List<Location> locations = _locationService.GetLocations();
            ViewBag.LocationList = new SelectList(locations, "LocationID", "LocationName");

            List<Book> availableBooks = _bookService.GetBooks().Where(b => b.IsAvailable == true).ToList();
            ViewBag.BookList = availableBooks.OrderBy(b => b.Title).Select(b => new SelectListItem {
                Value = b.BookID.ToString(),
                Text = $"{b.Title} by {b.Author} - {b.Condition} ({b.Genre}) [ID: {b.BookID}]",
            }).ToList();

            List<User> users = _userService.GetAllUsers();
            List<User> availableUsers = users
                 .OrderBy(u => u.Name)
                 .Where(u => !u.Loans.Any(l => l.LoanStatus != LoanStatusType.Returned))
                 .ToList();

            List<SelectListItem> userDisplayList = availableUsers
                .Select(u => new SelectListItem {
                    Value = u.UserID.ToString(),
                    Text = $"{u.Name} - ID: {u.UserID}"
                })
                .ToList();
            ViewBag.Users = userDisplayList;
            ViewBag.UserList = users
                .Select(u => new SelectListItem {
                    Value = u.UserID.ToString(),
                    Text = $"{u.Name} - ID: {u.UserID}"
                })
                .ToList();

            Loan loan = new Loan {
                DateBorrowed = DateTime.Today,
                DueDate = DateTime.Today.AddDays(14),
                LoanStatus = LoanStatusType.TakenOut
            };
            return View(loan);
        }

        [Authorize]
        [Authorize(Roles = "Admin, Staff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Loan loan) {
            if (!ModelState.IsValid) {
                List<Location> locations = _locationService.GetLocations();
                ViewBag.LocationList = new SelectList(locations, "LocationID", "LocationName", loan.LocationID);

                List<Book> availableBooks = _bookService.GetBooks()
                            .Where(b => b.IsAvailable == true)
                            .ToList();
                ViewBag.BookList = availableBooks.OrderBy(b => b.Title).Select(b => new SelectListItem {
                    Value = b.BookID.ToString(),
                    Text = $"{b.Title} by {b.Author} - {b.Condition} ({b.Genre}) [ID: {b.BookID}]",
                    Selected = b.BookID == loan.BookID
                }).ToList();

                List<User> users = _userService.GetAllUsers();
                List<User> availableUsers = users
                     .OrderBy(u => u.Name)
                     .Where(u => !u.Loans.Any(l => l.LoanStatus != LoanStatusType.Returned))
                     .ToList();

                ViewBag.UserList = availableUsers
                    .Select(u => new SelectListItem {
                        Value = u.UserID.ToString(),
                        Text = $"{u.Name} - ID: {u.UserID}",
                        Selected = u.UserID == loan.UserID
                    })
                    .ToList();

                return View(loan);
            }

            Book book = _bookService.GetBookByID(loan.BookID);
            if (book != null) {
                book.IsAvailable = false;
                _bookService.UpdateBook(book);
            }

            _loanService.AddLoan(loan);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id) {
            Loan loan = _loanService.GetLoans().FirstOrDefault(l => l.LoanID == id);
            if (loan == null) {
                return NotFound();
            }
            return View(loan);
        }

        [Authorize]
        [Authorize(Roles = "Admin, Staff")]
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

            List<User> users = _userService.GetAllUsers();
            ViewBag.UserList = new SelectList(users, "UserID", "Name", loan.UserID);
            return View(loan);
        }

        [Authorize]
        [Authorize(Roles = "Admin, Staff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Loan loan) {
            loan.LoanID = id;
            if (!ModelState.IsValid) {
                List<Location> locations = _locationService.GetLocations();
                ViewBag.LocationList = new SelectList(locations, "LocationID", "LocationName", loan.LocationID);

                List<Book> books = _bookService.GetBooks();
                ViewBag.BookList = new SelectList(books, "BookID", "Title", loan.BookID);

                List<User> users = _userService.GetAllUsers();
                ViewBag.UserList = new SelectList(users, "UserID", "Name", loan.UserID);
                return View(loan);
            }

            Loan originalLoan = _loanService.GetLoanById(loan.LoanID);

            if (originalLoan != null && originalLoan.BookID != loan.BookID) {
                Book oldBook = _bookService.GetBookByID(originalLoan.BookID);
                if (oldBook != null) {
                    oldBook.IsAvailable = true;
                    _bookService.UpdateBook(oldBook);
                }

                Book newBook = _bookService.GetBookByID(loan.BookID);
                if (newBook != null) {
                    newBook.IsAvailable = false;
                    _bookService.UpdateBook(newBook);
                }
            }

            if (loan.LoanStatus == LoanStatusType.Returned) {
                Book book = _bookService.GetBookByID(loan.BookID);
                if (book != null) {
                    book.IsAvailable = true;
                    _bookService.UpdateBook(book);
                }
            }
            _loanService.UpdateLoan(loan);
            return RedirectToAction("Index");
        }

        [Authorize]
        [Authorize(Roles = "Admin, Staff")]
        [HttpGet]
        public IActionResult Delete(int id) {
            Loan loan = _loanService.GetLoanById(id);
            if (loan == null) {
                return NotFound();
            }
            return View(loan);
        }

        [Authorize]
        [Authorize(Roles = "Admin, Staff")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id) {
            Loan loan = _loanService.GetLoanById(id);
            if (loan != null) {
                var book = _bookService.GetBookByID(loan.BookID);
                if (book != null) {
                    book.IsAvailable = true;
                    _bookService.UpdateBook(book);
                }
            }
            _loanService.DeleteLoan(id);
            return RedirectToAction("Index");
        }
    }
}

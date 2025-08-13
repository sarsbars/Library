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

        public LoanController(LoanService loanService ,LocationService locationService, BookService bookService, UserService userService) {
            _loanService = loanService;
            _locationService = locationService;
            _bookService = bookService;
            _userService = userService;
        }
        public IActionResult Index() {
            IEnumerable<Loan> loans;
            if (User.IsInRole("Admin")) {
                loans = _loanService.GetLoans();
            } else {
                // Temporarily show all loans to debug
                loans = _loanService.GetLoans();

                // Debug info - remove this later
                string userName = User.Identity.Name;
                System.Diagnostics.Debug.WriteLine($"Current user: {userName}");
                System.Diagnostics.Debug.WriteLine($"Total loans: {loans.Count()}");
                //string userName = User.Identity.Name;
                //loans = _loanService.GetLoans().Where(l => l.User.Name == userName);
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

            List<User> users = _userService.GetAllUsers();
            List<User> availableUsers = users
                 .Where(u => !u.Loans.Any(l => l.LoanStatus != LoanStatusType.Returned))
                 .ToList();

            List<SelectListItem> userDisplayList = availableUsers
                .Select(u => new SelectListItem {
                    Value = u.UserID.ToString(),
                    Text = $"{u.Name} - ID: {u.UserID}"
                })
                .ToList();
            ViewBag.Users = userDisplayList;

            Loan loan = new Loan {
                LoanID = 0;
                DateBorrowed = DateTime.Today,
                DueDate = DateTime.Today.AddDays(14),
                LoanStatus = LoanStatusType.TakenOut
            };
            return View(loan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Loan loan) {
            // Debug what's being received
            System.Diagnostics.Debug.WriteLine($"Received loan - BookID: {loan.BookID}, UserID: {loan.UserID}, LocationID: {loan.LocationID}");
            System.Diagnostics.Debug.WriteLine($"DateBorrowed: {loan.DateBorrowed}, DueDate: {loan.DueDate}");

            if (!ModelState.IsValid) {
                // Show validation errors
                foreach (var error in ModelState) {
                    foreach (var err in error.Value.Errors) {
                        System.Diagnostics.Debug.WriteLine($"Validation Error - {error.Key}: {err.ErrorMessage}");
                    }
                }
                List<Location> locations = _locationService.GetLocations();
                ViewBag.LocationList = new SelectList(locations, "LocationID", "LocationName", loan.LocationID);

                List<Book> books = _bookService.GetBooks()
                            .Where(b => b.IsAvailable == true)
                            .ToList();
                ViewBag.BookList = books.Select(b => new SelectListItem {
                    Value = b.BookID.ToString(),
                    Text = $"{b.Title} by {b.Author} - {b.Condition} ({b.Genre}) [ID: {b.BookID}]",
                    Selected = b.BookID == loan.BookID
                }).ToList();

                List<User> availableUsers = _userService.GetAllUsers()
                     .Where(u => !u.Loans.Any(l => l.LoanStatus != LoanStatusType.Returned))
                     .ToList();

                ViewBag.Users = availableUsers
                    .Select(u => new SelectListItem {
                        Value = u.UserID.ToString(),
                        Text = $"{u.Name} - ID: {u.UserID}",
                        Selected = u.UserID == loan.UserID
                    })
                    .ToList();

                // Your existing code for repopulating ViewBags...
                return View(loan);
            }

            // Add success message
            System.Diagnostics.Debug.WriteLine("Model is valid, proceeding with loan creation");

            //if (!ModelState.IsValid) {
            //    List<Location> locations = _locationService.GetLocations();
            //    ViewBag.LocationList = new SelectList(locations, "LocationID", "LocationName", loan.LocationID);

            //    List<Book> books = _bookService.GetBooks()
            //                .Where(b => b.IsAvailable == true)
            //                .ToList();
            //    ViewBag.BookList = books.Select(b => new SelectListItem {
            //        Value = b.BookID.ToString(),
            //        Text = $"{b.Title} by {b.Author} - {b.Condition} ({b.Genre}) [ID: {b.BookID}]",
            //        Selected = b.BookID == loan.BookID
            //    }).ToList();

            //    List<User> availableUsers = _userService.GetAllUsers()
            //         .Where(u => !u.Loans.Any(l => l.LoanStatus != LoanStatusType.Returned))
            //         .ToList();

            //    ViewBag.Users = availableUsers
            //        .Select(u => new SelectListItem {
            //            Value = u.UserID.ToString(),
            //            Text = $"{u.Name} - ID: {u.UserID}",
            //            Selected = u.UserID == loan.UserID
            //        })
            //        .ToList();
            //    return View(loan);
            //}
            Book book = _bookService.GetBookByID(loan.BookID);
            if (book != null) {
                book.IsAvailable = false;
                _bookService.UpdateBook(book);
            }

            _loanService.AddLoan(loan);
            System.Diagnostics.Debug.WriteLine("Loan created successfully");
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

            List<User> users = _userService.GetAllUsers();
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

                List<User> users = _userService.GetAllUsers();
                ViewBag.UserList = new SelectList(users, "UserID", "Name", loan.UserID);
                return View(loan);
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

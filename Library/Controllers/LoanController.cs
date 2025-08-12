using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers {
    public class LoanController : Controller {
        private readonly LoanService _loanService;
        private readonly LocationService _locationService;
        //private readonly BookService _bookService;
        //private readonly UserService _userService;

        public LoanController(LoanService loanService ,LocationService locationService) {
            _loanService = loanService;
            _locationService = locationService;
        }
        public IActionResult Index() {
            IEnumerable<Loan> loans;
            if (User.IsInRole("Admin")) {
                loans = _loanService.GetLoans();
                //books = _bookService.GetBooks();

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
            return View(new Loan());
        }

        [HttpPost]
        public IActionResult Create(Loan loan) {
            if(!ModelState.IsValid) {
                List<Location> locations = _locationService.GetLocations();
                ViewBag.LocationList = new SelectList(locations, "LocationID", "LocationName", loan.LocationID);
                return View(loan);
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
            return View(loan);
        }

        [HttpPost]
        public IActionResult Edit(Loan loan) {
            if (!ModelState.IsValid) {
                List<Location> locations = _locationService.GetLocations();
                ViewData["LocationList"] = new SelectList(locations, "LocationID", "LocationName", loan.LocationID);
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

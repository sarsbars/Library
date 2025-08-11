using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers {
    public class LoanController : Controller {
        private readonly LoanService _loanService;

        public LoanController(LoanService loanService) {
            _loanService = loanService;
        }
        public IActionResult Index() {
            IEnumerable<Loan> loans;
            if (User.IsInRole("Admin")) {
                loans = _loanService.GetLoans();
            } else {
                string userId = User.Identity.Name;
                loans = _loanService.GetLoans();
            }
                return View(loans);
        }

        public IActionResult Create() {
            return View(new Loan());
        }

        public IActionResult Create(Loan loan) {
            if(!ModelState.IsValid) {
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

        public IActionResult Edit(int id) {
            Loan loan = _loanService.GetLoanById(id);
            if (loan == null) {
                return NotFound();
            }
            return View(loan);
        }

        public IActionResult Edit(Loan loan) {
            if (!ModelState.IsValid) {
                return View(loan);
            }
            _loanService.UpdateLoan(loan);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            Loan loan = _loanService.GetLoanById(id);
            if (loan == null) {
                return NotFound();
            }
            return View(loan);
        }
        public IActionResult DeleteConfirmed(int id) {
            _loanService.DeleteLoan(id);
            return RedirectToAction("Index");
        }
    }
}

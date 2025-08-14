using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.DAL {
    public class LoanRepository {
        private readonly LibraryDBContext _context;

        public LoanRepository(LibraryDBContext context) {
            _context = context;
        }

        public List<Loan> GetLoans() {
            return _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Location)
                .Include(l => l.User)
                .ToList();
        }

        public Loan GetLoanById(int id) {
            return _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Location)
                .Include(l => l.User)
                .FirstOrDefault(l => l.LoanID == id);
        }

       public void AddLoan(Loan loan) {
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }

        public void UpdateLoan(Loan loan) {
            var existingLoan = _context.Loans.FirstOrDefault(l => l.LoanID == loan.LoanID);

            if (existingLoan != null) {
                existingLoan.BookID = loan.BookID;
                existingLoan.UserID = loan.UserID;
                existingLoan.LocationID = loan.LocationID;
                existingLoan.LoanStatus = loan.LoanStatus;
                existingLoan.DateBorrowed = loan.DateBorrowed;
                existingLoan.DueDate = loan.DueDate;
                _context.SaveChanges();
            }
        }

        public void DeleteLoan(int id) {
            Loan loan = _context.Loans
                .FirstOrDefault(l => l.LoanID == id);

            if(loan != null) {
                _context.Loans.Remove(loan);
                _context.SaveChanges();

            }
        }

        public int GetTotalLoans() {
            return GetLoans().Count();
        }

        public int GetOverdueBooksCount() {
            return GetLoans().Count(l => l.DueDate < DateTime.Today && l.LoanStatus != LoanStatusType.Returned);
        }
    }
}

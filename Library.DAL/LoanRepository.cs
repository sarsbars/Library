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

       public void AddLoan(Loan loan) {
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }

        public void UpdateLoan(Loan loan) {
            _context.Loans.Update(loan);
            _context.SaveChanges();
        }

        public void DeleteLoan(int id) {
            Loan loan = _context.Loans
                .FirstOrDefault(l => l.LoanID == id);

            if(loan != null) {
                _context.Loans.Remove(loan);
                _context.SaveChanges();

            }
        }
    }
}

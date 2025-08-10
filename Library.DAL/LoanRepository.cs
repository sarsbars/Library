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

       
    }
}

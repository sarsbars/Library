using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL {
    public class CheckoutRepository {
        private readonly LibraryDbContext _context;

        public CheckoutRepository(LibraryDbContext context) {
            _context = context;
        }

        public List<Book> GetCurrentLoans(int userId) {
            return _context.Loans
                .Where(l => l.UserId == userId && !l.Returned)
                .Select(l => l.Book)
                .ToList();
        }

        public List<Book> GetPendingHolds(int userId) {
            return _context.Holds
                .Where(h => h.UserId == userId && !h.PickedUp)
                .Select(h => h.Book)
                .ToList();
        }

        public List<Book> GetRecentBooks(int userId, int count) {
            return _context.Loans
                .Where(l => l.UserId == userId)
                .OrderByDescending(l => l.CheckoutDate)
                .Take(count)
                .Select(l => l.Book)
                .ToList();
        }
    }
}

using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL {
    public class BookRepository {
        private readonly LibraryDBContext _context;

        public BookRepository (LibraryDBContext context) {
            _context = context;
        }

        public Book GetBookByID(int ID) {
            return _context.Books.FirstOrDefault(b => b.BookID == ID);
        }
        public List<Book> GetBooks() {
            return _context.Books
                .Include(b => b.Location)
                .ToList();
        }
    }
}

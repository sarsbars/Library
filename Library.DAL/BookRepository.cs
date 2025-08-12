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

        public void AddBook(Book book) {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book) {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook (Book book) {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}

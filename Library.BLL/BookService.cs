using Library.DAL;
using Library.Models;

namespace Library.BLL {
    public class BookService {
        private readonly BookRepository _bookRepository;

        public BookService (BookRepository bookRepository) {
            _bookRepository = bookRepository;
        }
        public Book GetBookByID(int ID) {
            return _bookRepository.GetBookByID(ID);
        }
        public List<Book> GetBooks() {
            return _bookRepository.GetBooks();
        }

        public void AddBook(Book book) {
            if (book == null) {
                throw new ArgumentNullException(nameof(book), "Racer cannot be null");
            }

            _bookRepository.AddBook(book);
        }
    }
}

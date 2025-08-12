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
                throw new ArgumentNullException(nameof(book), "Book cannot be null");
            }

            _bookRepository.AddBook(book);
        }

        public void UpdateBook(Book updatedBook) {
            Book existingBook = _bookRepository.GetBookByID(updatedBook.BookID);
            if (existingBook == null) {
                throw new InvalidOperationException("Book not found");
            }

            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.ISBN = updatedBook.ISBN;
            existingBook.PublicationDate = updatedBook.PublicationDate;
            existingBook.Genre = updatedBook.Genre;
            existingBook.Condition = updatedBook.Condition;
            existingBook.IsAvailable = updatedBook.IsAvailable;
            existingBook.LocationID = updatedBook.LocationID;
            existingBook.LocationInLibrary = updatedBook.LocationInLibrary;

            _bookRepository.UpdateBook(existingBook);
        }
    }
}

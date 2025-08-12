using Library.DAL;
using Library.Models;

namespace Library.BLL {
    public class BookService {
        private readonly BookRepository _bookRepository;

        public BookService (BookRepository bookRepository) {
            _bookRepository = bookRepository;
        }

        public List<Book> GetBooks() {
            return _bookRepository.GetBooks();
        }

        //public List<Book> GetBookById() {
        //    return _bookRepository.GetBookById();
        //}
    }
}

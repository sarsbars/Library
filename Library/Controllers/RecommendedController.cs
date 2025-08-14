using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers {
    public class RecommendedController : Controller {
        private readonly UserService _userService;
        private readonly BookService _bookService;

        public RecommendedController (UserService userService, BookService bookService) {
            _userService = userService;
            _bookService = bookService;
        }
        [Authorize]
        public IActionResult Recommended () {
            string email = User?.Identity?.Name;
            User CurrentUser = _userService.GetCurrentUser(email);

            List<Book> Books = _bookService.GetBooks();

            List<GenreType> FavGenres = CurrentUser.Loans
                .GroupBy(l => l.Book.Genre)
                .OrderByDescending(x => x.Count())
                .Take(3)
                .Select(g => g.Key)
                .ToList();

            List<string> FavAuthors = CurrentUser.Loans
                .GroupBy(l => l.Book.Author)
                .OrderByDescending(x => x.Count())
                .Take(3)
                .Select(g => g.Key)
                .ToList();

            Dictionary<GenreType, List<Book>> GenreBooks = FavGenres
                .Select(genre => new {
                    Genre = genre,
                    Books = Books.Where(b => b.Genre == genre).Take(4).ToList()
                })
                .Where(g => g.Books.Any())
                .ToDictionary(g => g.Genre, g => g.Books);

            Dictionary<string, List<Book>> AuthorBooks = FavAuthors
                .Select(author => new {
                    Author = author,
                    Books = Books.Where(b => b.Author == author).Take(4).ToList()
                })
                .Where(g => g.Books.Any())
                .ToDictionary(a => a.Author, a => a.Books);

            List<Loan> PrevLoans = CurrentUser.Loans
                .Where(l => l.LoanStatus == LoanStatusType.Returned)
                .ToList();

            RecommendedViewModel viewModel = new RecommendedViewModel {
                User = CurrentUser,
                GenreBooks = GenreBooks,
                AuthorBooks = AuthorBooks,
                Loans = PrevLoans
            };

            return View(viewModel);
        }
    }
}

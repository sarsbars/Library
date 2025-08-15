using Library.DAL;
using Library.Models;

namespace Library.BLL {
    public class CheckoutService {
        private readonly CheckoutRepository _checkoutRepository;

        public CheckoutService(CheckoutRepository checkoutRepository) {
            _checkoutRepository = checkoutRepository;
        }

        public List<Book> GetCurrentLoans(int userId) => _checkoutRepository.GetCurrentLoans(userId);

        public List<Book> GetPendingHolds(int userId) => _checkoutRepository.GetPendingHolds(userId);

        public List<Book> GetRecentBooks(int userId, int count) => _checkoutRepository.GetRecentBooks(userId, count);
    }

}

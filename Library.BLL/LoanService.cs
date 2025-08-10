using Library.DAL;
using Library.Models;

namespace Library.BLL {
    public class LoanService {
        private readonly LoanRepository _loanRepository;

        public LoanService(LoanRepository loanRepository) {
            _loanRepository = loanRepository;
        }

        public List<Loan> GetLoans() {
            return _loanRepository.GetLoans();
        }

        public Loan GetLoanById(int id) {
            return _loanRepository.GetLoanById(id);
        }

        public void AddLoan(Loan loan) {
            if(loan == null) {
                throw new ArgumentNullException(nameof(loan), "Loan cannot be null");
            }
            _loanRepository.AddLoan(loan);
        }

        public void UpdateLoan(Loan loan) => _loanRepository.UpdateLoan(loan);
        public void DeleteLoan(int id) => _loanRepository.DeleteLoan(id);
    }
}

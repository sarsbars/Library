using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL {
    public class UserRepository {
        private readonly LibraryDBContext _context;

        public UserRepository(LibraryDBContext context) {
            _context = context;
        }

        public IQueryable<User> GetAllUsers() {
            return _context.Users
                .Include(u => u.Location)
                .Include(u => u.Loans);
        }

        public User? GetUserById(int id) {
            return _context.Users.Include(u => u.Location)
                                 .FirstOrDefault(u => u.UserID == id);
        }

        public User GetCurrentUser(string email) {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public void AddUser(User user) {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User updatedUser) {
            var existingUser = _context.Users.Find(updatedUser.UserID);
            if (existingUser != null) {
                existingUser.Name = updatedUser.Name;
                existingUser.Email = updatedUser.Email;
                existingUser.Role = updatedUser.Role;
                existingUser.LocationID = updatedUser.LocationID;
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int userId) {
            var user = _context.Users
                               .Include(u => u.Loans)
                               .FirstOrDefault(u => u.UserID == userId);

            if (user != null) {
                _context.Loans.RemoveRange(user.Loans);
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<Location> GetLocations() {
            return _context.Locations.ToList();
        }

        public bool UserExists(int id) {
            return _context.Users.Any(u => u.UserID == id);
        }
    }
}

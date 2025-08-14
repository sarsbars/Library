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

        public void AddUser(User user) {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user) {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user) {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public List<Location> GetLocations() {
            return _context.Locations.ToList();
        }

        public bool UserExists(int id) {
            return _context.Users.Any(u => u.UserID == id);
        }
    }
}

using Library.DAL;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.BLL {
    public class UserService {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository) {
            _userRepository = userRepository;
        }

        public IQueryable<User> FilterUsers(string? role, string? name, int? location) {
            var query = _userRepository.GetAllUsers();

            if (!string.IsNullOrEmpty(role) && Enum.TryParse(role, out RoleType parsedRole)) {
                query = query.Where(u => u.Role == parsedRole);
            }

            if (!string.IsNullOrEmpty(name)) {
                query = query.Where(u => u.Name.Contains(name));
            }

            if (location.HasValue) {
                query = query.Where(u => u.LocationID == location.Value);
            }

            return query;
        }

        public User? GetUserById(int id) => _userRepository.GetUserById(id);
        public List<User> GetAllUsers() {
            return _userRepository.GetAllUsers().ToList();
        }

        public void CreateUser(User user) => _userRepository.AddUser(user);

        public void UpdateUser(User user) => _userRepository.UpdateUser(user);

        public void DeleteUser(int id) {
            var user = _userRepository.GetUserById(id);
            if (user != null)
                _userRepository.DeleteUser(user);
        }

        public List<Location> GetAllLocations() => _userRepository.GetLocations();

        public bool UserExists(int id) => _userRepository.UserExists(id);
    }
}

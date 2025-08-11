using Library.DAL;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers {
    public class UserController : Controller {
        private readonly LibraryDBContext _context;

        public UserController(LibraryDBContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string roleFilter, string nameSearch, int? locationFilter) { 
            var users = _context.Users.Include(u => u.Location).AsQueryable();

            if (!string.IsNullOrEmpty(roleFilter) && Enum.TryParse(roleFilter, out RoleType parsedRole)) {
                users = users.Where(u => u.Role == parsedRole);
            }

            if (!string.IsNullOrEmpty(nameSearch)) {
                users = users.Where(u => u.Name.Contains(nameSearch));
            }

            if (locationFilter.HasValue) {
                users = users.Where(u => u.LocationID == locationFilter);
            }

            ViewBag.Locations = _context.Locations.ToList();
            return View(users.ToList());
        }

        public IActionResult Details(int? id) {
            if (id == null) return NotFound();

            var user = _context.Users.Include(u => u.Location)
                                     .FirstOrDefault(m => m.UserID == id);
            if (user == null) return NotFound();

            // Readers can only view their own profile
            if (User.IsInRole("Reader") && !IsCurrentUser(user.Email))
                return Forbid();

            return View(user);
        }

        private bool IsCurrentUser(string email) {
            return User.Identity != null && User.Identity.Name == email;
        }
    }
}

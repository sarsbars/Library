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

        // GET: User
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

    }
}

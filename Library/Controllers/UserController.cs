using Library.DAL;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
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

        [HttpGet]
        [Authorize(Roles = "Admin,Staff")]
        public IActionResult Create() {
            ViewBag.Locations = _context.Locations.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Staff")]
        public IActionResult Create(User user) {
            if (ModelState.IsValid) {
                // Staff cannot create Admin accounts
                if (User.IsInRole("Staff") && user.Role == RoleType.Admin)
                    return Forbid();

                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Locations = _context.Locations.ToList();
            return View(user);
        }

        public IActionResult Edit(int? id) {
            if (id == null) return NotFound();

            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            // Role restrictions:
            if (User.IsInRole("Staff") && user.Role == RoleType.Admin)
                return Forbid();

            if (User.IsInRole("Reader") && !IsCurrentUser(user.Email))
                return Forbid();

            ViewBag.Locations = _context.Locations.ToList();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User updatedUser) {
            if (id != updatedUser.UserID) return NotFound();

            // Prevent staff from editing admins
            if (User.IsInRole("Staff") && updatedUser.Role == RoleType.Admin)
                return Forbid();

            if (User.IsInRole("Reader") && !IsCurrentUser(updatedUser.Email))
                return Forbid();

            if (ModelState.IsValid) {
                try {
                    _context.Update(updatedUser);
                    _context.SaveChanges();
                } catch (DbUpdateConcurrencyException) {
                    if (!_context.Users.Any(e => e.UserID == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Locations = _context.Locations.ToList();
            return View(updatedUser);
        }


    }
}

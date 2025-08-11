using Library.DAL;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers {
    public class UserController : Controller {
        private readonly LibraryDBContext _context;

        public UserController(LibraryDBContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string role, string name, int? location) {
            var usersQuery = _context.Users.Include(u => u.Location).AsQueryable();

            if (!string.IsNullOrEmpty(role) && Enum.TryParse(role, out RoleType parsedRole)) {
                usersQuery = usersQuery.Where(u => u.Role == parsedRole);
            }

            if (!string.IsNullOrEmpty(name)) {
                usersQuery = usersQuery.Where(u => u.Name.Contains(name));
            }

            if (location.HasValue) {
                usersQuery = usersQuery.Where(u => u.LocationID == location);
            }

            var model = new UserFilterViewModel {
                Role = role,
                Name = name,
                LocationID = location,
                Users = usersQuery.ToList(),

                RoleList = Enum.GetValues(typeof(RoleType))
                    .Cast<RoleType>()
                    .Select(r => new SelectListItem { Value = r.ToString(), Text = r.ToString() })
                    .ToList(),

                LocationList = Enum.GetValues(typeof(LocationNameType))
                    .Cast<LocationNameType>()
                    .Select(l => new SelectListItem { Value = l.ToString(), Text = l.ToString() })
                    .ToList(),
            };

            return View(model);
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

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id) {
            if (id == null) return NotFound();

            var user = _context.Users.Include(u => u.Location)
                                     .FirstOrDefault(m => m.UserID == id);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id) {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}

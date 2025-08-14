using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers {
    public class UserController : Controller {
        private readonly UserService _userService;

        public UserController(UserService userService) {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index(string role, string name, int? location) {
            var usersQuery = _userService.FilterUsers(role, name, location);

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

            var user = _userService.GetUserById(id.Value);
            if (user == null) return NotFound();

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
            ViewBag.Locations = _userService.GetAllLocations();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Staff")]
        public IActionResult Create(User user) {
            if (ModelState.IsValid) {
                if (User.IsInRole("Staff") && user.Role == RoleType.Admin)
                    return Forbid();

                _userService.CreateUser(user);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Locations = _userService.GetAllLocations();
            return View(user);
        }

        public IActionResult Edit(int? id) {
            if (id == null) return NotFound();

            var user = _userService.GetUserById(id.Value);
            if (user == null) return NotFound();

            if (User.IsInRole("Staff") && user.Role == RoleType.Admin)
                return Forbid();
            if (User.IsInRole("Reader") && !IsCurrentUser(user.Email))
                return Forbid();

            ViewBag.Locations = _userService.GetAllLocations();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User updatedUser) {
            if (id != updatedUser.UserID) return NotFound();

            if (User.IsInRole("Staff") && updatedUser.Role == RoleType.Admin)
                return Forbid();
            if (User.IsInRole("Reader") && !IsCurrentUser(updatedUser.Email))
                return Forbid();

            if (ModelState.IsValid) {
                _userService.UpdateUser(updatedUser);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Locations = _userService.GetAllLocations();
            return View(updatedUser);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id) {
            if (id == null) return NotFound();

            var user = _userService.GetUserById(id.Value);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id) {
            _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
            
        }
    }
}

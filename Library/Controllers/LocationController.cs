using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace Library.Controllers {
    [Authorize] // Requires authentication for all actions
    public class LocationController : Controller {
        private readonly LocationService _locationService;

        public LocationController(LocationService locationService) {
            _locationService = locationService;
        }

        [AllowAnonymous]
        public IActionResult Index() {
            var locations = _locationService.GetLocations();
            return View(locations);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create() {
            ViewBag.LocationNameList = new SelectList(Enum.GetValues(typeof(LocationNameType))
                .Cast<LocationNameType>()
                .Select(l => new SelectListItem { Text = l.ToString(), Value = l.ToString() }),
                "Value", "Text");
            return View(new Location());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Location location) {
            if (!ModelState.IsValid) {
                ViewBag.LocationNameList = new SelectList(Enum.GetValues(typeof(LocationNameType))
                    .Cast<LocationNameType>()
                    .Select(l => new SelectListItem { Text = l.ToString(), Value = l.ToString() }),
                    "Value", "Text");
                return View(location);
            }
            try {
                _locationService.AddLocation(location);
                return RedirectToAction(nameof(Index));
            } catch (Exception ex) {
                ModelState.AddModelError("", $"Error creating location: {ex.Message}");
                ViewBag.LocationNameList = new SelectList(Enum.GetValues(typeof(LocationNameType))
                    .Cast<LocationNameType>()
                    .Select(l => new SelectListItem { Text = l.ToString(), Value = l.ToString() }),
                    "Value", "Text");
                return View(location);
            }
        }

        [Authorize(Roles = "Admin,Staff")]
        public IActionResult Details(int id) {
            var location = _locationService.GetLocationByID(id);
            if (location == null) {
                return NotFound();
            }
            return View(location);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Staff")]
        public IActionResult Edit(int id) {
            var location = _locationService.GetLocationByID(id);
            if (location == null) {
                return NotFound();
            }
            ViewBag.LocationNameList = new SelectList(Enum.GetValues(typeof(LocationNameType))
                .Cast<LocationNameType>()
                .Select(l => new SelectListItem { Text = l.ToString(), Value = l.ToString() }),
                "Value", "Text", location.LocationName.ToString());
            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Staff")]
        public IActionResult Edit(Location location) {
            if (!ModelState.IsValid) {
                ViewBag.LocationNameList = new SelectList(Enum.GetValues(typeof(LocationNameType))
                    .Cast<LocationNameType>()
                    .Select(l => new SelectListItem { Text = l.ToString(), Value = l.ToString() }),
                    "Value", "Text", location.LocationName.ToString());
                return View(location);
            }
            try {
                _locationService.UpdateLocation(location);
                return RedirectToAction(nameof(Index));
            } catch (Exception ex) {
                ModelState.AddModelError("", $"Error updating location: {ex.Message}");
                ViewBag.LocationNameList = new SelectList(Enum.GetValues(typeof(LocationNameType))
                    .Cast<LocationNameType>()
                    .Select(l => new SelectListItem { Text = l.ToString(), Value = l.ToString() }),
                    "Value", "Text", location.LocationName.ToString());
                return View(location);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id) {
            var location = _locationService.GetLocationByID(id);
            if (location == null) {
                return NotFound();
            }
            return View(location);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id) {
            try {
                _locationService.DeleteLocation(id);
                return RedirectToAction(nameof(Index));
            } catch (Exception ex) {
                TempData["ErrorMessage"] = $"Error deleting location: {ex.Message}. Ensure no books, users, or loans are associated with this location.";
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }
}
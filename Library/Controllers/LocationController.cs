using Library.BLL;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Library.Controllers {
    [Authorize]
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
            return View(new LocationViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(LocationViewModel viewModel) {
            if (!ModelState.IsValid) {
                return View(viewModel);
            }
            try {
                var location = new Location {
                    LocationID = viewModel.LocationID,
                    Address = viewModel.Address,
                    PhoneNumber = viewModel.PhoneNumber
                };
                if (Enum.TryParse<LocationNameType>(viewModel.LocationName, true, out var locationName)) {
                    location.LocationName = locationName;
                    location.CustomName = null;
                } else {
                    location.LocationName = LocationNameType.Custom;
                    location.CustomName = viewModel.LocationName;
                }
                _locationService.AddLocation(location);
                return RedirectToAction(nameof(Index));
            } catch (Exception ex) {
                ModelState.AddModelError("", $"Error creating location: {ex.Message}");
                return View(viewModel);
            }
        }
        [Authorize(Roles = "Admin,Staff,Reader")]
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
            var viewModel = new LocationViewModel {
                LocationID = location.LocationID,
                LocationName = location.LocationName.ToString(),
                Address = location.Address,
                PhoneNumber = location.PhoneNumber
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Staff")]
        public IActionResult Edit(LocationViewModel viewModel) {
            if (!ModelState.IsValid) {
                return View(viewModel);
            }
            try {
                var location = _locationService.GetLocationByID(viewModel.LocationID);
                if (location == null) {
                    return NotFound();
                }
                location.Address = viewModel.Address;
                location.PhoneNumber = viewModel.PhoneNumber;
                if (Enum.TryParse<LocationNameType>(viewModel.LocationName, true, out var locationName)) {
                    location.LocationName = locationName;
                    location.CustomName = null;
                } else {
                    location.LocationName = LocationNameType.Custom;
                    location.CustomName = viewModel.LocationName;
                }
                _locationService.UpdateLocation(location);
                return RedirectToAction(nameof(Index));
            } catch (Exception ex) {
                ModelState.AddModelError("", $"Error updating location: {ex.Message}");
                return View(viewModel);
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
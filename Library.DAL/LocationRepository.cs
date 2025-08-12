using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAL {
    public class LocationRepository {
        private readonly LibraryDBContext _context;

        public LocationRepository(LibraryDBContext context) {
            _context = context;
        }

        public List<Location> GetLocations() {
            return _context.Locations.ToList();
        }
        public Location GetLocationById(int id) {
            return _context.Locations.FirstOrDefault(l => l.LocationID == id);
        }

        public void AddLocation(Location location) {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public Location GetLocationByID(int LocationID) {
            return _context.Locations.FirstOrDefault(l => l.LocationID == LocationID);
        }

        public void UpdateLocation(Location location) {
            _context.Locations.Update(location);
            _context.SaveChanges();
        }

        public void DeleteLocation(int id) {
            var location = _context.Locations.FirstOrDefault(l => l.LocationID == id);
            if (location != null) {
                _context.Locations.Remove(location);
                _context.SaveChanges();
            }
        }

        public void AddBook(Book book, Location location) {
            location.Books.Add(book);
            _context.SaveChanges();
        }

        public void RemoveBook (Book book, Location location) {
            location.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}

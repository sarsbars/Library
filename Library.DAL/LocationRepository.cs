using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL {
    public class LocationRepository {
        private readonly LibraryDBContext _context;

        public LocationRepository (LibraryDBContext context) {
            _context = context;
        }

        public List<Location> GetLocations () {
            return _context.Locations.ToList();
        }

        public Location GetLocationByID(int LocationID) {
            return _context.Locations.FirstOrDefault(l => l.LocationID == LocationID);
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

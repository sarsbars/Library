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

        public void AddBook(Book book, Location location) {
            location.Books.Add(book);
            _context.SaveChanges();
        }
    }
}

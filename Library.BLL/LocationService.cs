using Library.DAL;
using Library.Models;

namespace Library.BLL {
    public class LocationService {
        private readonly LocationRepository _locationRepository;

        public LocationService (LocationRepository locationRepository) {
            _locationRepository = locationRepository;
        }

        public List<Location> GetLocations () {
            return _locationRepository.GetLocations();
        }

        public void AddBook(Book book, Location location) {
            _locationRepository.AddBook(book, location);
        }
    }
}
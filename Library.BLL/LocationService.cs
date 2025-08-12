using Library.DAL;
using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.BLL {
    public class LocationService {
        private readonly LocationRepository _locationRepository;

        public LocationService(LocationRepository locationRepository) {
            _locationRepository = locationRepository;
        }

        public List<Location> GetLocations() {
            return _locationRepository.GetLocations();
        }

        public Location GetLocationById(int id) {
            return _locationRepository.GetLocationById(id);
        }

        public void AddLocation(Location location) {
            _locationRepository.AddLocation(location);
        }

        public void UpdateLocation(Location location) {
            _locationRepository.UpdateLocation(location);
        }

        public void DeleteLocation(int id) {
            _locationRepository.DeleteLocation(id);

        public void AddBook(Book book, Location location) {
            _locationRepository.AddBook(book, location);

        }
    }
}
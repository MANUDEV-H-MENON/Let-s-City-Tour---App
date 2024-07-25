using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<(IEnumerable<City>, PaginationMetaData)> GetCitiesAsync(string? name, string? searchQuery, int pageNumber, int pageSize);

        Task<City?> GetCityAsync(int cityId, bool includePointOfInterest);
        Task<IEnumerable<PointOfInterest>> GetPointOfInterestsForCityAsync(int cityId);
        Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId);
        Task<bool> CityNameMatchesCityId(string? cityName, int cityId);
        Task<bool> CityExistAsync(int cityId);

        Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest);
        Task<bool> SaveChangesAsync();

        void DeletePointOfInterest(PointOfInterest pointOfInterest);

        Task<IEnumerable<TourCoordinator>> GetTourCoordinatorsAsync();
        Task<TourCoordinator?> GetTourCoordinatorAsync(int tourCoordinatorId);
        Task AddTourCoordinatorAsync(TourCoordinator tourCoordinator);
        void DeleteTourCoordinator(TourCoordinator tourCoordinator);
        Task<bool> TourCoordinatorExistsAsync(int tourCoordinatorId);
    }
}

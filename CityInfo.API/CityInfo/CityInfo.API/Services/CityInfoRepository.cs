using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : CityInfoContextAbstractRepository, ICityInfoRepository
    {

        public CityInfoRepository(CityInfoContext context): base(context)
        {
        }
        
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<(IEnumerable<City>, PaginationMetaData)> GetCitiesAsync(string? name, string? searchQuery, int pageNumber, int pageSize)
        {
            //if (string.IsNullOrEmpty(name) && string.IsNullOrWhiteSpace(searchQuery))
            //{
            //    return await GetCitiesAsync();
            //}

            var collection = _context.Cities as IQueryable<City>;
            if (!string.IsNullOrEmpty(name)) 
            {
                name = name.Trim();
                collection = collection.Where(c => c.Name == name);
            }

            if(!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(c => c.Name.Contains(searchQuery) || (c.Description!=null && c.Description.Contains(searchQuery)));
            }
            var totalItemCount = await collection.CountAsync();
            var paginationMetaData = new PaginationMetaData(totalItemCount, pageSize, pageNumber);
            var collectionToReturn = await collection.OrderBy(c=>c.Name)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();  

            return (collectionToReturn, paginationMetaData);
        }

        public async Task<City?> GetCityAsync(int cityId, bool includePointOfInterest)
        {
            if (includePointOfInterest)
            {
                return await _context.Cities.Include(c=>c.PointOfInterests).Where(c => c.Id == cityId).FirstOrDefaultAsync();
            }
            return await _context.Cities.Where(c => c.Id == cityId).FirstOrDefaultAsync();
        }

        public async Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId)
        {
            return await _context.PointOfInterests.Where(p=>p.Id == pointOfInterestId && cityId == p.CityId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointOfInterestsForCityAsync(int cityId)
        {
            return await _context.PointOfInterests.Where(p => cityId == p.CityId).ToListAsync();

        }

        public async Task<bool> CityExistAsync(int cityId) 
        {
            return await _context.Cities.AnyAsync(c=>c.Id == cityId);
        }

        public async Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest)
        {
            var city = await GetCityAsync(cityId, false);
            if(city != null) 
            {
                city.PointOfInterests.Add(pointOfInterest);
            }
        }

        public async Task<bool> SaveChangesAsync() 
        {
            return (await _context.SaveChangesAsync()>=0);
        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest) 
        {
            _context.PointOfInterests.Remove(pointOfInterest);
        }

        public async Task<bool> CityNameMatchesCityId(string? cityName, int cityId) 
        {
            return await _context.Cities.AnyAsync(c=> (c.Name == cityName && c.Id == cityId));
        }

// function to call the stored procedure to fetch both cities and its  pointsof ineterst
        public async Task<IEnumerable<City>> GetCitiesWithPointsOfInterestAsync()
        {
            return await _context.Cities.FromSqlRaw("EXEC GetCitiesWithPointsOfInterest").ToListAsync();
        }

        public async Task<IEnumerable<TourCoordinator>> GetTourCoordinatorsAsync()
        {
            return await _context.TourCoordinators.ToListAsync();
        }

        public async Task<TourCoordinator?> GetTourCoordinatorAsync(int tourCoordinatorId)
        {
            return await _context.TourCoordinators.FindAsync(tourCoordinatorId);
        }

        public async Task AddTourCoordinatorAsync(TourCoordinator tourCoordinator)
        {
            if (tourCoordinator == null)
            {
                throw new ArgumentNullException(nameof(tourCoordinator));
            }

            await _context.TourCoordinators.AddAsync(tourCoordinator);
        }

        public void DeleteTourCoordinator(TourCoordinator tourCoordinator)
        {
            if (tourCoordinator == null)
            {
                throw new ArgumentNullException(nameof(tourCoordinator));
            }

            _context.TourCoordinators.Remove(tourCoordinator);
        }

        public async Task<bool> TourCoordinatorExistsAsync(int tourCoordinatorId)
        {
            return await _context.TourCoordinators.AnyAsync(e => e.Id == tourCoordinatorId);
        }



    }
}

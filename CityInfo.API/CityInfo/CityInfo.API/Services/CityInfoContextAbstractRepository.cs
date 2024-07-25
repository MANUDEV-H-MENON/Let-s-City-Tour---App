using CityInfo.API.DbContexts;

namespace CityInfo.API.Services
{
    public class CityInfoContextAbstractRepository
    {
        protected readonly CityInfoContext _context;

        public CityInfoContextAbstractRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}

using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options)
       : base(options)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointOfInterests { get; set; }

        public DbSet<TourCoordinator> TourCoordinators { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<City>().Property(c => c.Id).ValueGeneratedOnAdd();

            //modelBuilder.Entity<PointOfInterest>()
            //    .Property(p => p.Id)
            //    .ValueGeneratedOnAdd();

            //modelBuilder.Entity<City>().HasData(
            //    new City("Thrissur") { Id = 1, Description = "Cultural CApital of Kerala" },
            //    new City("Kochi") { Id = 2, Description = "Tech CApital of Kerala" },
            //    new City("Trivandrum") { Id = 3, Description = "OOriginal CApital of Kerala" }
            //);

            //modelBuilder.Entity<PointOfInterest>().HasData(
            //    new PointOfInterest("snehatheeram") { Id = 1, CityId = 1, Description = "Beach It is" },
            //    new PointOfInterest("Fort kochi") { Id = 2, CityId = 2, Description = "It's a Tourist spot" },
            //    new PointOfInterest("Kumbalangi") { Id = 3, CityId = 2, Description = "It's a backwaters spot" },
            //    new PointOfInterest("Kovalam") { Id = 4, CityId = 3, Description = "Beach It is" }
            //    );

            modelBuilder.Entity<City>().HasData(
                new City { Id = 4, Name = "New York", Description = "The Big Apple" },
                new City { Id = 5, Name = "Tokyo", Description = "One of the busiest cities in the world" },
                new City { Id = 6, Name = "Paris", Description = "The City of Light" },
                new City { Id = 7, Name = "London", Description = "The capital of England" },
                new City { Id = 8, Name = "Sydney", Description = "The largest city in Australia" },
                new City { Id = 9, Name = "Rio de Janeiro", Description = "Home of the famous Christ the Redeemer statue" },
                new City { Id = 10, Name = "Cape Town", Description = "Known for its harbour and Table Mountain" },
                new City { Id = 11, Name = "Moscow", Description = "The capital of Russia" },
                new City { Id = 12, Name = "Beijing", Description = "The capital of China" },
                new City { Id = 13, Name = "Cairo", Description = "The largest city in Africa" }

            );

            modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest { Id = 5, CityId = 4, Name = "Statue of Liberty", Description = "A colossal neoclassical sculpture on Liberty Island" },
                new PointOfInterest { Id = 6, CityId = 5, Name = "Tokyo Tower", Description = "A communications and observation tower in the Shiba-koen district" },
                new PointOfInterest { Id = 7, CityId = 6, Name = "Eiffel Tower", Description = "A wrought-iron lattice tower on the Champ de Mars" },
                new PointOfInterest { Id = 8, CityId = 7, Name = "London Eye", Description = "A giant Ferris wheel on the South Bank of the River Thames" },
                new PointOfInterest { Id = 9, CityId = 8, Name = "Sydney Opera House", Description = "A multi-venue performing arts centre at Sydney Harbour" },
                new PointOfInterest { Id = 10, CityId = 9, Name = "Christ the Redeemer", Description = "An Art Deco statue of Jesus Christ in Rio de Janeiro" },
                new PointOfInterest { Id = 11, CityId = 10, Name = "Table Mountain", Description = "A flat-topped mountain forming a prominent landmark overlooking the city of Cape Town" },
                new PointOfInterest { Id = 12, CityId = 11, Name = "Red Square", Description = "A city square in Moscow" },
                new PointOfInterest { Id = 13, CityId = 12, Name = "Great Wall of China", Description = "A series of fortifications that were built across the historical northern borders of China" },
                new PointOfInterest { Id = 14, CityId = 13, Name = "Pyramids of Giza", Description = "The oldest of the Seven Wonders of the Ancient World, and the only one to remain largely intact" }
            );

            modelBuilder.Entity<TourCoordinator>().HasData(
                new TourCoordinator { Id = 1, Name = "John Doe", CityId = 4 },
                new TourCoordinator { Id = 2, Name = "Jane Smith", CityId = 5 },
                new TourCoordinator { Id = 3, Name = "Robert Johnson", CityId = 6 },
                new TourCoordinator { Id = 4, Name = "Mary Davis", CityId = 7 },
                new TourCoordinator { Id = 5, Name = "James Brown", CityId = 8 },
                new TourCoordinator { Id = 6, Name = "Patricia Garcia", CityId = 8 },
                new TourCoordinator { Id = 7, Name = "Michael Miller", CityId = 10 },
                new TourCoordinator { Id = 8, Name = "Linda Martinez", CityId = 11 },
                new TourCoordinator { Id = 9, Name = "William Rodriguez", CityId = 12 },
                new TourCoordinator { Id = 10, Name = "Elizabeth Taylor", CityId = 13 },
                new TourCoordinator { Id = 11, Name = "David Anderson", CityId = 11 },
                new TourCoordinator { Id = 12, Name = "Jennifer Thomas", CityId = 12 },
                new TourCoordinator { Id = 13, Name = "Richard Jackson", CityId = 13 },
                new TourCoordinator { Id = 14, Name = "Susan White", CityId = 5 },
                new TourCoordinator { Id = 15, Name = "Joseph Harris", CityId = 6 }
            );

            base.OnModelCreating(modelBuilder);
        }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        //{
        //    optionsBuilder.UseSqlite("Connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}

using CityInfo.API.Models;

namespace CityInfo.API.Responses
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }
       // public static CitiesDataStore Current { get;  } = new CitiesDataStore();  //singleton
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Thrissur",
                    Description = "Cultural Capital",
                    PointOfInterests =  new List<PointOfInterestDto>(){
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Athirapilly",
                            Description = "Waterfall",
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Thrissur Town",
                            Description = "Pooram",
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Trivandrum",
                    Description = "capital of kerala",
                    PointOfInterests =  new List<PointOfInterestDto>(){
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "shankumukham",
                            Description = "beach",
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "varkala",
                            Description = "beach",
                        }
                    }
                }
            };
        }

    }
}

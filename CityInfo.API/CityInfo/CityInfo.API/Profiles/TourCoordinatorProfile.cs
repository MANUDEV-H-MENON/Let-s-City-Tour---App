using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;

namespace CityInfo.API.Profiles
{
    public class TourCoordinatorProfile : Profile
    {
        public TourCoordinatorProfile() {
            CreateMap<Entities.TourCoordinator, Models.TourCoordinatorsDto>();
            CreateMap<TourCoordinatorsCreationDto, TourCoordinator>();
            CreateMap<TourCoordinatorsDto, TourCoordinator>();
            CreateMap<TourCoordinator, TourCoordinatorsDto>();
        }
        // complete profile with tourcordinator dto and entity mappings
        //CreateMap<TourCoordinatorForCreationDto, TourCoordinator>();
        //CreateMap<TourCoordinatorForUpdateDto, TourCoordinator>();
        //CreateMap<TourCoordinator, TourCoordinatorForUpdateDto>();

    }
}

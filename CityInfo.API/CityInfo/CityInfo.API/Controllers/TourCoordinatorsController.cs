using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/tourcoordinators")]
[ApiController]
public class TourCoordinatorsController : ControllerBase
{
    private readonly ICityInfoRepository _cityInfoRepository;
    private readonly IMapper _mapper;

    public TourCoordinatorsController(ICityInfoRepository cityInfoRepository, IMapper mapper)
    {
        _cityInfoRepository = cityInfoRepository;
        _mapper = mapper;
    }

    // GET: api/TourCoordinators
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TourCoordinator>>> GetTourCoordinators()
    {
       var tourCoordinators = await _cityInfoRepository.GetTourCoordinatorsAsync();
        return Ok(_mapper.Map<IEnumerable<TourCoordinatorsDto>>(tourCoordinators));
    }

    // GET: api/TourCoordinators/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TourCoordinatorsDto>> GetTourCoordinator(int id)
    {
        var tourCoordinator = await _cityInfoRepository.GetTourCoordinatorAsync(id);

        if (tourCoordinator == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<TourCoordinatorsDto>(tourCoordinator));
    }

    // PUT: api/TourCoordinators/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTourCoordinator(int id, TourCoordinatorsCreationDto tourCoordinatorsCreationDto)
    {
        if (!await _cityInfoRepository.TourCoordinatorExistsAsync(id))
        {
            return NotFound();
        }

        var tourCoordinatorEntity = await _cityInfoRepository.GetTourCoordinatorAsync(id);

        if (tourCoordinatorEntity == null)
        {
            return NotFound();
        }

        _mapper.Map(tourCoordinatorsCreationDto, tourCoordinatorEntity);

        await _cityInfoRepository.SaveChangesAsync();

        return NoContent();
    }

    // POST: api/TourCoordinators
    [HttpPost]
    public async Task<ActionResult<TourCoordinator>> PostTourCoordinator(TourCoordinatorsCreationDto tourCoordinatorCreationDto)
    {
        var tourCoordinatoro = _mapper.Map<TourCoordinator>(tourCoordinatorCreationDto);

        var citiesList = await _cityInfoRepository.GetCitiesAsync();
        var city = citiesList.FirstOrDefault(c => c.Name == tourCoordinatorCreationDto.CityName);
        if(city == null) 
        {
            return NotFound();
        }

        tourCoordinatoro.CityId = city.Id;
        await _cityInfoRepository.AddTourCoordinatorAsync(tourCoordinatoro);

        await _cityInfoRepository.SaveChangesAsync();
        var createdTourCoordinatoro = _mapper.Map<TourCoordinator>(tourCoordinatoro);

        return CreatedAtAction("GetTourCoordinator", new { id = createdTourCoordinatoro.Id }, tourCoordinatoro);
    }

    // DELETE: api/TourCoordinators/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<TourCoordinator>> DeleteTourCoordinator(int id)
    {
        var tourCoordinator = await _cityInfoRepository.GetTourCoordinatorAsync(id);
        if (tourCoordinator == null)
        {
            return NotFound();
        }

        _cityInfoRepository.DeleteTourCoordinator(tourCoordinator);
        await _cityInfoRepository.SaveChangesAsync();
        return tourCoordinator;
    }
}

using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class TourCoordinatorsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class TourCoordinatorsCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string CityName { get; set; }
    }
}

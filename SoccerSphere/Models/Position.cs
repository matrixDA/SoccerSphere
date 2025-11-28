using System.ComponentModel.DataAnnotations;

namespace SoccerSphere.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        [Required(ErrorMessage = "Position Name is required.")]
        public string PositionName { get; set; }
    }
}

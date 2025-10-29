using System.ComponentModel.DataAnnotations;

namespace SoccerSphere.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required(ErrorMessage = "Team Name is required.")]
        public string TeamName { get; set; }

        public decimal Revenue { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        public int Wins { get; set; }

        public int Loss { get; set; }

        public int Draws { get; set; }
    }
}

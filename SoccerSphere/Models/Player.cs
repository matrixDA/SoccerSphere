using System.ComponentModel.DataAnnotations;

namespace SoccerSphere.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        [Required(ErrorMessage = "Please enter player's name.")]
        public string PlayerName { get; set; }

        public int Goals { get; set; }

        public int Assists { get; set; }

        public int MatchesPlayed { get; set; }

        public double Rating { get; set; }
    }
}

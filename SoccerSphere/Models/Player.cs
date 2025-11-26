using System.ComponentModel.DataAnnotations;

namespace SoccerSphere.Models
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "Player Name is Required.")]
        public string PlayerName { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Goals is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Goals must be at least zero.")]
        public int? Goals { get; set; }

        [Required(ErrorMessage = "Assists is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Assists must be at least zero.")]
        public int? Assists { get; set; }

        [Required(ErrorMessage = "Matches Played is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Matches Played must at least be zero.")]
        public int? MatchesPlayed { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [DisplayFormat(DataFormatString = "{0:F1}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true)]
        [Range(0, 10)]
        public double? Rating { get; set; }

        [Required(ErrorMessage = "Team is Required.")]
        public int TeamId { get; set; }

        public Team? Team { get; set; }
    }
}
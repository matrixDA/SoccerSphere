using System.ComponentModel.DataAnnotations;

namespace SoccerSphere.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required(ErrorMessage = "Team Name is required.")]
        public string? TeamName { get; set; }

        [Required(ErrorMessage = "Revenue is required.")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true)]
        [Range(0, double.MaxValue)]
        public decimal? Revenue { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Wins is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Wins must be at least zero.")]
        public int? Wins { get; set; }

        [Required(ErrorMessage = "Losses is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Losses must be at least zero.")]
        public int? Loses { get; set; }

        [Required(ErrorMessage = "Draws is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Draws must be at least zero.")]
        public int? Draws { get; set; }
    }
}

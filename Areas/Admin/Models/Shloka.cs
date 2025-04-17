using System.ComponentModel.DataAnnotations;

namespace The_voice_of_geeta.Areas.Admin.Models
{
    public class Shloka
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Adhyay Number is required.")]
        [Range(1, 18, ErrorMessage = "Adhyay Number must be between 1 and 18.")]
        public int AdhyayNumber { get; set; }

        [Required(ErrorMessage = "Shloka Description is required.")]
        [MaxLength(500, ErrorMessage = "Shloka Description cannot exceed 500 characters.")]
        public string ShlokaDescription { get; set; }
        public bool IsVisible { get; set; } = false;
    }
}

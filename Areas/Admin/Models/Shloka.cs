using System.ComponentModel.DataAnnotations;

namespace The_voice_of_geeta.Areas.Admin.Models
{
    public class Shloka
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AdhyayNumber { get; set; }

        [Required]
        public string ShlokaDescription { get; set; }
    }
}

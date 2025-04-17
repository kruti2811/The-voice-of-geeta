using System.ComponentModel.DataAnnotations;

namespace The_voice_of_geeta.Models
{
    public class Usermodel
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid(); // Unique User ID

        [Required]
        [StringLength(50)]
        public string Username { get; set; } // Username

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Email Address

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; } // Password

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Registration Date

        public bool IsActive { get; set; } = true; // Status (Active/Inactive)
    }
}

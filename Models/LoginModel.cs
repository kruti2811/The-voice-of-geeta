using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace The_voice_of_geeta.Models
{
    public class LoginModel
    {
        [Key]
        public Guid User_id { get; set; } //unique id provide
        [Required,NotNull]
        public string Username { get; set; }
        [Required,NotNull]
        public string Password { get; set; }

    }
}

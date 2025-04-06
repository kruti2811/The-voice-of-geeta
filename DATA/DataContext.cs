using The_voice_of_geeta.Models;
using Microsoft.EntityFrameworkCore;
using The_voice_of_geeta.Areas.Admin.Models;
namespace The_voice_of_geeta.DATA
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<LoginModel> login { get; set; }
        public DbSet<Usermodel> Users { get; set; }
        public DbSet<Shloka> Shlokas { get; set; }
    }
}

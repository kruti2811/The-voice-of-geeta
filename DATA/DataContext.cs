using The_voice_of_geeta.Models;
using Microsoft.EntityFrameworkCore;
namespace The_voice_of_geeta.DATA
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<LoginModel> login { get; set; }
        public DbSet<Usermodel> Users { get; set; }

    }
}

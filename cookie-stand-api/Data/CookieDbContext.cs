using cookie_stand_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand_api.Data
{
    public class CookieDbContext : DbContext
    {
        public CookieDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HourlySales>().HasKey(key => new
            {
                key.ID,
                key.CookieStandID
            });

           
        }
        public DbSet<CookieStand> CookieStands { get; set; }
        public DbSet<HourlySales> HourlySales { get; set; }
    }
}

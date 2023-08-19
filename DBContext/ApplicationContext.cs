using AdService.Models;
using Microsoft.EntityFrameworkCore;

namespace AdService.DBContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Advert> Adverts { get; set; }
    }
}

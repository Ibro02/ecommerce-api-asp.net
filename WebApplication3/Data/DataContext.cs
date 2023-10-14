
global using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Data
{
    public class DataContext : DbContext
    {


        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Models.User> Users => Set<Models.User>();

        public DbSet<Models.Role> Roles => Set<Models.Role>();

        public DbSet<Models.City> Cities => Set<Models.City>();

        public DbSet<Models.Country> Countries => Set<Models.Country>(); 

    }
}

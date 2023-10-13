
global using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Data
{
    public class DataContext : DbContext
    {


        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Models.User> Users => Set<Models.User>();

        public DbSet<Models.Role> Roles => Set<Models.Role>();


    }
}

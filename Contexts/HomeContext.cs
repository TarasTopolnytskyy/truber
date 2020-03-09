using Microsoft.EntityFrameworkCore;
using Truber_Project.Models;


namespace Truber_Project.Contexts
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions options) : base (options){}
        public DbSet<User> Users {get; set; }
        public DbSet<Driver> Drivers {get; set; }
        public DbSet<Truber> Trubers {get; set; }
    }
}
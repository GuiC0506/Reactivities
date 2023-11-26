using Microsoft.EntityFrameworkCore;
using Domain;


namespace Persistence
{
    public class DataContext : DbContext
    {   
        // database instance
        public DataContext(DbContextOptions options) : base(options) {}
        
        // activities table
        public DbSet<Activity> Activities { get; set; }
    }
}
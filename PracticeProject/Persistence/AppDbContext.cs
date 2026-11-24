using Microsoft.EntityFrameworkCore;
using PracticeProject.Models;
namespace PracticeProject.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        
        {
        
        }
        public List<User> GetUsersFromSP() { 
            return Users.FromSqlRaw("EXEC getuser_sp").ToList(); 
        }
    }
}

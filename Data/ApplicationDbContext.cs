using Microsoft.EntityFrameworkCore;
using TermianlMVCApp.Models;

namespace TermianlMVCApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        private ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Command> Commands { get; set; }
    }
}

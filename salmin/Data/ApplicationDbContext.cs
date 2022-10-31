using Microsoft.EntityFrameworkCore;
using salmin.Models;

namespace salmin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<Category> categories { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using HelloWorld.Models;

namespace HelloWorld.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        public DbSet<Product> Products => Set<Product>();
    }
}
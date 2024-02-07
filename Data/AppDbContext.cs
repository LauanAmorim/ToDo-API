using Trendx_toDo.Models;
using Microsoft.EntityFrameworkCore;

namespace Trendx_toDo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("DataSource=app.db; Cache=Shared ");
    }
}

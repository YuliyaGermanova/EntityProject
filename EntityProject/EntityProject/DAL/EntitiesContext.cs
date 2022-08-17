using EntityProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityProject.DAL
{
    public class EntitiesContext : DbContext
    {
        public DbSet<Entity> Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=Entities.db");
    }
}

using demo_project_01_stream.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace demo_project_01_stream.Models.Data
{
    public class MonsterDataContext : DbContext
    {
        public MonsterDataContext(DbContextOptions<MonsterDataContext> options) : base(options)
        {

        }

        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Alignment> Alignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monster>().ToTable("Monster");
            modelBuilder.Entity<Alignment>().ToTable("Alignment");
        }
    }
}

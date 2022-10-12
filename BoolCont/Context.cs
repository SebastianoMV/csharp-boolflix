using csharp_boolflix.Models;
using Microsoft.EntityFrameworkCore;


namespace csharp_boolflix.BoolContext
{
    public class Context : DbContext
    {
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<MediaInfo> Infos { get; set; }
        public DbSet<TVSeries> Series { get; set; }
        public DbSet<Film> Films { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=boolflix-db;Integrated Security=True");
        }
    }
}

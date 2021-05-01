using Microsoft.EntityFrameworkCore;
using NahhasWeb.Shared.Entities;

namespace NahhasWeb.Shared
{
    public class NahhasWebDbContext : DbContext
    {
        public NahhasWebDbContext(DbContextOptions<NahhasWebDbContext> options) : base(options) { }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Quote> Quotes { get; set; }
    }
}
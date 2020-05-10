using Microsoft.EntityFrameworkCore;
using MvcMeetcha.Models;

namespace MvcMeetcha.Data
{
    public class MvcMeetchaContext : DbContext
    {
        public MvcMeetchaContext (DbContextOptions<MvcMeetchaContext> options)
            : base(options)
        {
        }

        public DbSet<Group> Group { get; set; }
        public DbSet<Meetup> Meetup { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Meetup>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }   
    }
}
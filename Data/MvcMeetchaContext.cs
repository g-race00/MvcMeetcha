using Microsoft.EntityFrameworkCore;
using MvcMeetcha.Models;

namespace MvcMeetcha.Data
{
    public class MvcMeetchaContext : DbContext
    {
        public MvcMeetchaContext (DbContextOptions<MvcMeetchaContext> options): base(options)
        {
        }

        public DbSet<Group> Group { get; set; }
        public DbSet<GroupType> GroupType { get; set; }
        public DbSet<Meetup> Meetup { get; set; }
        public DbSet<MeetupType> MeetupType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<GroupType>().HasData(
                new { GroupTypeId = 1, GroupTypeName = "Arts"},
                new { GroupTypeId = 2, GroupTypeName = "Beliefs"},
                new { GroupTypeId = 3, GroupTypeName = "Book Clubs"},
                new { GroupTypeId = 4, GroupTypeName = "Career & Business"},
                new { GroupTypeId = 5, GroupTypeName = "Dance"},
                new { GroupTypeId = 6, GroupTypeName = "Family"},
                new { GroupTypeId = 7, GroupTypeName = "Fashion & Beauty"},
                new { GroupTypeId = 8, GroupTypeName = "Film"},
                new { GroupTypeId = 9, GroupTypeName = "Food & Drinks"},
                new { GroupTypeId = 10, GroupTypeName = "Health & Wellness"},
                new { GroupTypeId = 11, GroupTypeName = "Hobbies & Crafts"},
                new { GroupTypeId = 12, GroupTypeName = "Language & Culture"},
                new { GroupTypeId = 13, GroupTypeName = "Learning"},
                new { GroupTypeId = 14, GroupTypeName = "Movements"},
                new { GroupTypeId = 15, GroupTypeName = "Music"},
                new { GroupTypeId = 16, GroupTypeName = "Outdoors & Adventure"},
                new { GroupTypeId = 17, GroupTypeName = "Pets"},
                new { GroupTypeId = 18, GroupTypeName = "Photography"},
                new { GroupTypeId = 19, GroupTypeName = "Sci-Fi & Games"},
                new { GroupTypeId = 20, GroupTypeName = "Social"},
                new { GroupTypeId = 21, GroupTypeName = "Sports & Fitness"},
                new { GroupTypeId = 22, GroupTypeName = "Writing"}
            );

            modelBuilder.Entity<Meetup>().ToTable("Meetup");
            modelBuilder.Entity<MeetupType>().HasData(
                new { MeetupTypeId = 1, MeetupTypeName = "Event"},
                new { MeetupTypeId = 2, MeetupTypeName = "Workshop"},
                new { MeetupTypeId = 3, MeetupTypeName = "Seminar"},
                new { MeetupTypeId = 4, MeetupTypeName = "Conference"},
                new { MeetupTypeId = 5, MeetupTypeName = "Programme"}
            );
        }

    }
}
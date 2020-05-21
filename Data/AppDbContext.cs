using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MvcMeetcha.Data
{
    public class AppDbContext: IdentityDbContext<Account>
    {
        public DbSet<Admin> Admins { get; set; } = null!;
        public DbSet<Member> Members { get; set; } = null!;
        public DbSet<GroupType> GroupTypes { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<MeetupType> MeetupTypes { get; set; } = null!;
        public DbSet<Meetup> Meetups { get; set; } = null!;
        public DbSet<GroupComment> GroupComments { get; set; } = null!;
        public DbSet<MeetupComment> MeetupComments { get; set; } = null!;
        public DbSet<GroupMember> GroupMembers { get; set; } = null!;
        public DbSet<MeetupAttendee> MeetupAttendees { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options): 
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Account>()
                .HasOne(account => account.Admin)
                .WithOne(admin => admin!.Account)
                .HasForeignKey<Admin>(admin => admin.AspNetUserId);

            builder.Entity<Account>()
                .HasOne(account => account.Member)
                .WithOne(member => member!.Account)
                .HasForeignKey<Member>(member => member.AspNetUserId);

            builder.Entity<GroupType>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder.Entity<GroupType>().HasData(
                new { Id = 1,  Name = "Arts"},
                new { Id = 2,  Name = "Beliefs"},
                new { Id = 3,  Name = "Book Clubs"},
                new { Id = 4,  Name = "Career & Business"},
                new { Id = 5,  Name = "Dance"},
                new { Id = 6,  Name = "Family"},
                new { Id = 7,  Name = "Fashion & Beauty"},
                new { Id = 8,  Name = "Film"},
                new { Id = 9,  Name = "Food & Drinks"},
                new { Id = 10, Name = "Health & Wellness"},
                new { Id = 11, Name = "Hobbies & Crafts"},
                new { Id = 12, Name = "Language & Culture"},
                new { Id = 13, Name = "Learning"},
                new { Id = 14, Name = "Movements"},
                new { Id = 15, Name = "Music"},
                new { Id = 16, Name = "Outdoors & Adventure"},
                new { Id = 17, Name = "Pets"},
                new { Id = 18, Name = "Photography"},
                new { Id = 19, Name = "Sci-Fi & Games"},
                new { Id = 20, Name = "Social"},
                new { Id = 21, Name = "Sports & Fitness"},
                new { Id = 22, Name = "Writing"});

            builder.Entity<Group>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder.Entity<MeetupType>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder.Entity<MeetupType>().HasData(
                new { Id = 1, Name = "Event"},
                new { Id = 2, Name = "Workshop"},
                new { Id = 3, Name = "Seminar"},
                new { Id = 4, Name = "Conference"},
                new { Id = 5, Name = "Programme"});

            builder.Entity<MeetupComment>()
                .HasOne(comment => comment.Commenter)
                .WithMany(member => member.MeetupComments)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<MeetupComment>()
                .HasOne(comment => comment.Commenter)
                .WithMany(member => member.MeetupComments)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<GroupMember>()
                .HasKey(x => new { x.GroupId, x.MemberId });
            
            builder.Entity<GroupMember>()
                .HasIndex(x => new { x.MemberId, x.GroupId });

            builder.Entity<MeetupAttendee>()
                .HasOne(attendee => attendee.Member)
                .WithMany(member => member.MeetupAttendees)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<MeetupAttendee>()
                .HasOne(attendee => attendee.Meetup)
                .WithMany(meetup => meetup.MeetupAttendees)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<MeetupAttendee>()
                .HasKey(x => new { x.MeetupId, x.MemberId });

            builder.Entity<MeetupAttendee>()
                .HasIndex(x => new { x.MemberId, x.MeetupId });

        }
    }
}

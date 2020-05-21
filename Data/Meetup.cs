using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMeetcha.Data
{
    public class Meetup
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; } = null!;

        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;

        public int MeetupTypeId { get; set; }
        public MeetupType MeetupType { get; set; } = null!;

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Column(TypeName = "time")]
        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan StartTime { get; set; }

        [Column(TypeName = "time")]
        [Display(Name = "End Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan EndTime { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        public string Venue { get; set; } = null!;

        [DataType(DataType.Currency)]
        [Column(TypeName = "smallmoney")]
        public decimal Fee { get; set; }

        public string Status { get; set; } = null!;

        public int HostId { get; set; }
        [ForeignKey("HostId")]
        public Member Host { get; set; } = null!;

        [Column(TypeName = "nvarchar(256)")]
        public string Image { get; set; } = null!;

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = null!;

        public List<MeetupAttendee>? MeetupAttendees { get; set; }

        public List<MeetupComment>? MeetupComments { get; set; }
    }
}

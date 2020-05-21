using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMeetcha.Data
{
    public class Member
    {
        public int Id { get; set; }

        public string AspNetUserId { get; set; } = null!;
        public Account Account { get; set; } = null!;

        public List<GroupComment>? GroupComments { get; set; }

        public List<MeetupComment>? MeetupComments { get; set; }

        public List<GroupMember>? GroupMembers { get; set; }

        public List<MeetupAttendee>? MeetupAttendees { get; set; }

        public List<Meetup>? HostingMeetups { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMeetcha.Data
{
    public class MeetupAttendee
    {
        public int MeetupId { get; set; }
        public Meetup Meetup { get; set; } = null!;

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;
    }
}

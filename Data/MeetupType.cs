using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMeetcha.Data
{
    public class MeetupType
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        public string Name { get; set; } = null!;

        public List<Meetup>? Meetups { get; set; }
    }
}

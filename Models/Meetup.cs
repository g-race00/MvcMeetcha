using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMeetcha.Models
{
    public class Meetup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        public string Venue { get; set; }
        public string Type { get; set; }
        public  decimal Price { get; set; }
        public string Poster { get; set; }
        public int VolunteersNum { get; set; }
        public int AttendeesNum { get; set; }
    }
}
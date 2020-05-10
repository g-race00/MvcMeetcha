using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMeetcha.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
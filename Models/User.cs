using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMeetcha.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public string Name { get; set; }
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string TeleNum { get; set; }
        public string Email { get; set; }
    }
}
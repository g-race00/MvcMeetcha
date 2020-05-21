using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMeetcha.Data
{
    public class Admin
    {
        public int Id { get; set; }

        public string AspNetUserId { get; set; } = null!;
        public Account Account { get; set; } = null!;
    }
}

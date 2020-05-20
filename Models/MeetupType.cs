using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;   
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMeetcha.Models
{
    public class MeetupType
    {
        [Key]
        public int MeetupTypeId { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string MeetupTypeName { get; set; }

    }
}
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMeetcha.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        
        [Required]
        [DisplayName("Name")]
        [Column(TypeName = "nvarchar(50)")]
        public string GroupName { get; set; }

        [Required]
        [DisplayName("Description")]
        [Column(TypeName = "nvarchar(500)")]
        public string GroupDescription { get; set; }
        
        [Required]
        [DisplayName("Type")]
        public int GroupTypeId { get; set; }

        public GroupType GroupType { get; set;}
        
        [DisplayName("Image")]
        [Column(TypeName = "nvarchar(100)")]
        public string GroupImageName { get; set; }

        [Required]
        [NotMapped]
        [DisplayName("Group Image")]
        public IFormFile GroupImageFile { get; set; }

        public virtual ICollection<Meetup> GroupMeetups { get; set;}
    }
}
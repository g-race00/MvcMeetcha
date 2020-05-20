using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMeetcha.Models
{
    public class Meetup
    {
        [Key]
        public int MeetupId { get; set; }
        
        [Required]
        [DisplayName("Name")]
        [Column(TypeName = "nvarchar(50)")]
        public string MeetupName { get; set; }

        [Required]
        [DisplayName("Description")]
        [Column(TypeName = "nvarchar(500)")]
        public string MeetupDescription { get; set; }

        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MeetupDate { get; set; }

        [Required]
        [DisplayName("Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime MeetupStartTime { get; set; }
        
        [Required]
        [DisplayName("End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime MeetupEndTime { get; set; }

        [Required]
        [DisplayName("Type")]
        public int MeetupTypeId { get; set; }

        public MeetupType MeetupType { get; set;}

        [Required]
        [DisplayName("Venue")]
        [Column(TypeName = "nvarchar(100)")]
        public string MeetupVenue { get; set; }

        [Required]
        [DisplayName("Fee")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MeetupFee { get; set; }

        [DisplayName("Image")]
        [Column(TypeName = "nvarchar(100)")]
        public string MeetupImageName { get; set; }

        [Required]
        [NotMapped]
        [DisplayName("Meetup Image")]
        public IFormFile MeetupImageFile { get; set; }

        public int GroupId { get; set;}
        public  virtual Group Group { get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetcha.Data
{
    public class MeetupComment
    {
        public int Id { get; set; }

        public int CommenterId { get; set; }
        [ForeignKey("CommenterId")]
        public Member Commenter { get; set; } = null!;

        public int MeetupId { get; set; }
        public Meetup Meetup { get; set; } = null!;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateAndTime { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; } = null!;
    }
}

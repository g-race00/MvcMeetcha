using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMeetcha.Data
{
    public class GroupComment
    {
        public int Id { get; set; }

        public int CommenterId { get; set; }
        [ForeignKey("CommenterId")]
        public Member Commenter { get; set; } = null!;

        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateAndTime { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; } = null!;
    }
}

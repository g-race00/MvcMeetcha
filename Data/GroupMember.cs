using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetcha.Data
{
    public class GroupMember
    {
        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;

        [Column(TypeName = "nvarchar(64)")]
        public string Role { get; set; } = null!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoinedDate { get; set; }
    }
}

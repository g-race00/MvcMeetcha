using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetcha.Data
{
    public class Group
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; } = null!;

        public int GroupTypeId { get; set; }
        public GroupType GroupType { get; set; } = null!;

        [Column(TypeName = "nvarchar(256)")]
        public string Image { get; set; } = null!;

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = null!;

        public List<Meetup>? Meetups { get; set; }

        public List<GroupMember>? GroupMembers { get; set; }

        public List<GroupComment>? GroupComments { get; set; }
    }
}

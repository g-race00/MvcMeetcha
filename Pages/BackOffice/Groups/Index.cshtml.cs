using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using MvcMeetcha.Data;
using MvcMeetcha.Pages;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MvcMeetcha.Pages.BackOffice.Groups
{
    public class IndexModel: CustomPageModel
    {
        public IndexModel(
            UserManager<Account> userManager,
            AppDbContext dbContext):
            base(userManager, dbContext)
        {
        }

        public CustomPaginatedList<ViewModel> Groups { get; set; } = null!;

        public class ViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public int GroupTypeId { get; set; }
            public string GroupTypeName { get; set; } = null!;
            public int MembersCount { get; set; }
            public string Email { get; set; } = null!;
        }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? PageNumber { get; set; }

        public async Task OnGetAsync()
        {
            await Initialize();

            var items = _dbContext.Groups.AsNoTracking()
                .Select(group_ => new ViewModel
                {
                    Id = group_.Id,
                    Name = group_.Name,
                    GroupTypeId = group_.GroupTypeId,
                    GroupTypeName = group_.GroupType.Name,
                    MembersCount = group_.GroupMembers.Count()
                });

            /*
            var items = _dbContext.Groups.AsNoTracking()
                .Include(group_ => group_.GroupType)
                .Join(
                    _dbContext.GroupMembers.AsNoTracking()
                        .GroupBy(
                            groupMember => groupMember.GroupId,
                            (groupId, groupMembers) => new 
                            {
                                GroupId = groupId,
                                MembersCount = groupMembers.Count()
                            }),
                    group_ => group_.Id,
                    groupMemberCount => groupMemberCount.GroupId.DefaultIfEmpty(),
                    (group_, groupMemberCount) => new ViewModel
                    {
                        Id = group_.Id,
                        Name = group_.Name,
                        GroupTypeId = group_.GroupTypeId,
                        GroupTypeName = group_.GroupType.name,
                        MembersCount = groupMemberCount.MembersCount
                    });
            */

            if (!string.IsNullOrEmpty(SearchString))
            {
                items = items.Where(x => x.Name.Contains(SearchString));
            }

            items = items.OrderBy(x => x.Name);

            Groups = await CustomPaginatedList<ViewModel>.CreateAsync(
                items,
                PageNumber ?? 1,
                10);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Meetcha.Data;
using Meetcha.Pages;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Meetcha.Pages.BackOffice.Groups
{
    public class DetailsModel: CustomPageModel
    {
        public DetailsModel(
            UserManager<Account> userManager,
            AppDbContext dbContext):
            base(userManager, dbContext)
        {
        }

        public Group Group { get; set; } = null!;

        public int GroupMemberCount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await Initialize();

            if (id == null)
            {
                return NotFound();
            }

            var item = await _dbContext.Groups.AsNoTracking()
                .Include(x => x.GroupType)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound();
            }

            Group = item;

            GroupMemberCount = await _dbContext.GroupMembers.AsNoTracking()
                .Where(x => x.GroupId == Group.Id)
                .CountAsync();

            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Meetcha.Data;
using Meetcha.Pages;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Meetcha.Pages.BackOffice.Groups
{
    public class DeleteModel: CustomPageModel
    {
        private IWebHostEnvironment _hostEnv;

        public DeleteModel(
            UserManager<Account> userManager,
            AppDbContext dbContext,
            IWebHostEnvironment hostEnv):
            base(userManager, dbContext)
        {
            _hostEnv = hostEnv;
        }

        public Group Group { get; set; } = null!;

        [TempData]
        public string? StatusMessage { get; set; }

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

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
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

            CustomHelper.DeleteImage(_hostEnv.WebRootPath, Group.Image);

            _dbContext.Groups.Remove(Group);
            await _dbContext.SaveChangesAsync();

            StatusMessage = "Group deleted";

            return RedirectToPage("./Index");
        }
    }
}

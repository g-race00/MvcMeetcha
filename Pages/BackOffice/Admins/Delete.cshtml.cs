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

namespace MvcMeetcha.Pages.BackOffice.Admins
{
    public class DeleteModel: CustomPageModel
    {
        public DeleteModel(
            UserManager<Account> userManager,
            AppDbContext dbContext):
            base(userManager, dbContext)
        {
        }

        public Admin Admin { get; set; } = null!;

        [TempData]
        public string? StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await Initialize();

            if (id == null)
            {
                return NotFound();
            }

            var admin = await _dbContext.Admins
                .Include(a => a.Account)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (admin == null)
            {
                return NotFound();
            }

            Admin = admin;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            await Initialize();

            if (id == null)
            {
                return NotFound();
            }

            var admin = await _dbContext.Admins
                .Include(a => a.Account)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (admin == null)
            {
                ModelState.AddModelError(string.Empty, "Cannot find admin to delete");
                return RedirectToPage("./Index");
            }

            Admin = admin;

            _dbContext.Admins.Remove(Admin);
            await _dbContext.SaveChangesAsync();

            var result = await _userManager.DeleteAsync(Admin.Account);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return Page();
            }

            StatusMessage = "Admin deleted";

            return RedirectToPage("./Index");
        }
    }
}

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

namespace Meetcha.Pages.BackOffice.Members
{
    public class DeleteModel: CustomPageModel
    {
        public DeleteModel(
            UserManager<Account> userManager,
            AppDbContext dbContext):
            base(userManager, dbContext)
        {
        }

        public Member Member { get; set; } = null!;

        [TempData]
        public string? StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await Initialize();

            if (id == null)
            {
                return NotFound();
            }

            var member = await _dbContext.Members
                .Include(a => a.Account)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (member == null)
            {
                return NotFound();
            }

            Member = member;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            await Initialize();

            if (id == null)
            {
                return NotFound();
            }

            var member = await _dbContext.Members
                .Include(a => a.Account)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (member == null)
            {
                ModelState.AddModelError(string.Empty, "Cannot find member to delete");
                return RedirectToPage("./Index");
            }

            Member = member;

            _dbContext.Members.Remove(Member);
            await _dbContext.SaveChangesAsync();

            var result = await _userManager.DeleteAsync(Member.Account);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return Page();
            }

            StatusMessage = "Member deleted";

            return RedirectToPage("./Index");
        }
    }
}

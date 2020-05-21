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
    public class EditModel: CustomPageModel
    {
        public EditModel(
            UserManager<Account> userManager,
            AppDbContext dbContext):
            base(userManager, dbContext)
        {
        }

        public Member Member { get; set; } = null!;

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        [TempData]
        public string? StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            public int Id { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; } = null!;

            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string? NewPassword { get; set; }
        }

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

            Input = new InputModel
            {
                Id = Member.Id,
                Email = Member.Account.Email
            };

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            await Initialize();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var member = await _dbContext.Members
                .Include(a => a.Account)
                .FirstOrDefaultAsync(m => m.Id == Input.Id);

            if (member == null)
            {
                return NotFound();
            }

            Member = member;

            var result = await _userManager.SetEmailAsync(Member.Account, Input.Email);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                
                return Page();
            }

            if (!string.IsNullOrEmpty(Input.NewPassword))
            {
                result = await _userManager.RemovePasswordAsync(Member.Account);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    
                    return Page();
                }

                result = await _userManager.AddPasswordAsync(Member.Account, Input.NewPassword);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return Page();
                }
            }

            StatusMessage = "Member Updated";

            return RedirectToPage("./Index");
        }
    }
}

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
    public class CreateModel: CustomPageModel
    {
        public CreateModel(
            UserManager<Account> userManager,
            AppDbContext dbContext):
            base(userManager, dbContext)
        {
        }

        public async Task OnGetAsync()
        {
            await Initialize();
        }

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        [TempData]
        public string? StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Username")]
            public string Username { get; set; } = null!;

            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; } = null!;

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; } = null!;
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

            var user = new Account
            {
                UserName = Input.Username,
                Email = Input.Email
            };

            var result = await _userManager.CreateAsync(user, Input.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                
                return Page();
            }

            _dbContext.Admins.Add(new Admin { AspNetUserId = user.Id });
            await _dbContext.SaveChangesAsync();

            StatusMessage = "Admin created";

            return RedirectToPage("./Index");
        }
    }
}

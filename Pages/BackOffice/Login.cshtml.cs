using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using MvcMeetcha.Data;
using MvcMeetcha.Pages;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MvcMeetcha.Pages.BackOffice
{
    [AllowAnonymous]
    public class LoginModel: CustomPageModel
    {
        private readonly SignInManager<Account> _signInManager;

        public LoginModel(
            UserManager<Account> userManager,
            AppDbContext dbContext,
            SignInManager<Account> signInManager):
            base(userManager, dbContext)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        public string? ReturnUrl { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        [TempData]
        public string? StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; } = null!;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = null!;
        }

        public void OnGet(string? returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/BackOffice");

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/BackOffice");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _dbContext.Users
                .Include(a => a.Admin)
                .Include(a => a.Member)
                .Where(a => a.UserName == Input.Username)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            if (user.Admin == null)
            {
                ModelState.AddModelError(string.Empty, "Please login using admin account.");
                return Page();
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, false, lockoutOnFailure: false);

            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            return LocalRedirect(returnUrl);
        }

        public async Task<IActionResult> OnPostInitAdminAsync()
        {
            var user = new Account
            {
                UserName = "admin",
                Email = "admin@example.com"
            };

            var result = await _userManager.CreateAsync(user, "Admin123!");

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

            var signInResult = await _signInManager.PasswordSignInAsync("admin", "Admin123!", false, lockoutOnFailure: false);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            StatusMessage = "Admin created. Username: \"admin\", Password: \"Admin123!\"";

            return RedirectToPage("./Index");
        }
    }
}

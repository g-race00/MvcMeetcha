using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using MvcMeetcha.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MvcMeetcha.Pages
{
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

            returnUrl = returnUrl ?? Url.Content("~/");

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = await _dbContext.Users
                    .Include(a => a.Admin)
                    .Include(a => a.Member)
                    .Where(a => a.UserName == Input.Username)
                    .FirstOrDefaultAsync();

                if (user.Member == null)
                {
                    ModelState.AddModelError(string.Empty, "Please login using member account.");
                    return Page();
                }

                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }

                if (result.IsLockedOut)
                {
                    return RedirectToPage("/Lockout");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}

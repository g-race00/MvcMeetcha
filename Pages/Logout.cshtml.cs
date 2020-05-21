using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MvcMeetcha.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MvcMeetcha.Pages
{
    public class LogoutModel: PageModel
    {
        private readonly SignInManager<Account> _signInManager;

        public LogoutModel(SignInManager<Account> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string? returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}

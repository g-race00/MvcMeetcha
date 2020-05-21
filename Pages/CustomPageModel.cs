using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Meetcha.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Meetcha.Pages
{
    public class CustomPageModel: PageModel
    {
        protected readonly UserManager<Account> _userManager;
        protected readonly AppDbContext _dbContext;

        public CustomPageModel(
            UserManager<Account> userManager,
            AppDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public Account? ThisUser { get; private set; }

        public async Task Initialize()
        { 
            string userId = _userManager.GetUserId(User);

            ThisUser = await _dbContext.Users
                .Include(a => a.Admin)
                .Include(a => a.Member)
                .Where(a => a.Id == userId)
                .FirstOrDefaultAsync();
        }
    }
}

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
    public class IndexModel: CustomPageModel
    {
        public IndexModel(
            UserManager<Account> userManager,
            AppDbContext dbContext):
            base(userManager, dbContext)
        {
        }

        public CustomPaginatedList<ViewModel> Admins { get; set; } = null!;

        public class ViewModel
        {
            public int Id { get; set; }
            [Display(Name = "Username")]
            public string UserName { get; set; } = null!;
            public string Email { get; set; } = null!;
        }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? PageNumber { get; set; }

        public async Task OnGetAsync()
        {
            await Initialize();

            var admins = _dbContext.Admins
                .Join(
                    _dbContext.Users,
                    admin => admin.AspNetUserId,
                    account => account.Id,
                    (admin, account) => new ViewModel 
                    { 
                        Id = admin.Id,
                        UserName = account.UserName,
                        Email = account.Email
                    });

            if (!string.IsNullOrEmpty(SearchString))
            {
                admins = admins.Where(x => x.UserName.Contains(SearchString));
            }

            admins = admins.OrderBy(x => x.UserName);

            Admins = await CustomPaginatedList<ViewModel>.CreateAsync(
                admins.OrderBy(x => x.UserName).AsNoTracking(),
                PageNumber ?? 1,
                10);
        }
    }
}

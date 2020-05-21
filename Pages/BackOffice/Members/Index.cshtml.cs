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
    public class IndexModel: CustomPageModel
    {
        public IndexModel(
            UserManager<Account> userManager,
            AppDbContext dbContext):
            base(userManager, dbContext)
        {
        }

        public CustomPaginatedList<ViewModel> Members { get; set; } = null!;

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

            var members = _dbContext.Members
                .Join(
                    _dbContext.Users,
                    member => member.AspNetUserId,
                    account => account.Id,
                    (member, account) => new ViewModel 
                    { 
                        Id = member.Id,
                        UserName = account.UserName,
                        Email = account.Email
                    });

            if (!string.IsNullOrEmpty(SearchString))
            {
                members = members.Where(x => x.UserName.Contains(SearchString));
            }

            members = members.OrderBy(x => x.UserName);

            Members = await CustomPaginatedList<ViewModel>.CreateAsync(
                members.OrderBy(x => x.UserName).AsNoTracking(),
                PageNumber ?? 1,
                10);
        }
    }
}

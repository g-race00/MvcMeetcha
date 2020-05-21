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
    public class IndexModel: CustomPageModel
    {
        public IndexModel(
            UserManager<Account> userManager,
            AppDbContext dbContext):
            base(userManager, dbContext)
        {
        }

        public async Task OnGetAsync()
        {
            await Initialize();
        }
    }
}

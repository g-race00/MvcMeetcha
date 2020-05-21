using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Meetcha.Data;
using Meetcha.Pages;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Meetcha.Pages.BackOffice.Groups
{
    public class CreateModel: CustomPageModel
    {
        private IWebHostEnvironment _hostEnv;

        public CreateModel(
            UserManager<Account> userManager,
            AppDbContext dbContext,
            IWebHostEnvironment hostEnv):
            base(userManager, dbContext)
        {
            _hostEnv = hostEnv;
        }

        public async Task OnGetAsync()
        {
            await Initialize();
            await InitProperties();
        }

        public SelectList GroupTypes { get; set; } = null!;

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        [TempData]
        public string? StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; } = null!;

            [Required]
            [Display(Name = "Group Type")]
            public int GroupTypeId { get; set; }

            [Required]
            [Display(Name = "Image")]
            public IFormFile ImageFile { get; set; } = null!;

            [Required]
            [Display(Name = "Description")]
            public string Description { get; set; } = null!;
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            await Initialize();
            await InitProperties();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (await _dbContext.Groups.AsNoTracking().Where(x => x.Name == Input.Name).AnyAsync())
            {
                ModelState.AddModelError("Input.Name", "Name has been used");
                return Page();
            }

            if (!await _dbContext.GroupTypes.AsNoTracking().Where(x => x.Id == Input.GroupTypeId).AnyAsync())
            {
                ModelState.AddModelError("Input.GroupTypeId", "Invalid group type");
                return Page();
            }

            var imageName = await CustomHelper.SaveImageAsync(_hostEnv.WebRootPath, Input.ImageFile);

            _dbContext.Groups.Add(new Group
            {
                Name = Input.Name,
                GroupTypeId = Input.GroupTypeId,
                Image = imageName,
                Description = Input.Description
            });
            await _dbContext.SaveChangesAsync();

            StatusMessage = "Group created";

            return RedirectToPage("./Index");
        }

        private async Task InitProperties()
        {
            GroupTypes = new SelectList(
                await _dbContext.GroupTypes.AsNoTracking().ToListAsync(),
                "Id", "Name");
        }
    }
}

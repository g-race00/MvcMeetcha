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
    public class EditModel: CustomPageModel
    {
        private IWebHostEnvironment _hostEnv;

        public EditModel(
            UserManager<Account> userManager,
            AppDbContext dbContext,
            IWebHostEnvironment hostEnv):
            base(userManager, dbContext)
        {
            _hostEnv = hostEnv;
        }

        public Group Group { get; set; } = null!;

        public SelectList GroupTypes { get; set; } = null!;

        [TempData]
        public string? StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        public class InputModel
        {
            [Required]
            public int Id { get; set; }

            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; } = null!;

            [Required]
            [Display(Name = "Group Type")]
            public int GroupTypeId { get; set; }

            [Display(Name = "Image")]
            public IFormFile? ImageFile { get; set; } = null!;

            [Required]
            [Display(Name = "Description")]
            public string Description { get; set; } = null!;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await Initialize();
            await InitProperties();

            if (id == null)
            {
                return NotFound();
            }

            var item = await _dbContext.Groups.AsNoTracking()
                .Include(x => x.GroupType)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound();
            }

            Group = item;

            Input = new InputModel
            {
                Id = Group.Id,
                Name = Group.Name,
                GroupTypeId = Group.GroupTypeId,
                Description = Group.Description
            };

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            await Initialize();
            await InitProperties();

            var item = await _dbContext.Groups
                .Include(x => x.GroupType)
                .Where(x => x.Id == Input.Id)
                .FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound();
            }

            Group = item;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (await _dbContext.Groups.AsNoTracking()
                .Where(x => x.Name == Input.Name && x.Id != Input.Id)
                .AnyAsync())
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

            Group.Name = Input.Name;
            Group.GroupTypeId = Input.GroupTypeId;
            if (!string.IsNullOrEmpty(imageName))
            {
                Group.Image = imageName;
            }
            Group.Description = Input.Description;
            await _dbContext.SaveChangesAsync();

            StatusMessage = "Group Updated";

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

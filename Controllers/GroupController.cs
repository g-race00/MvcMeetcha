using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMeetcha.Data;
using MvcMeetcha.Models;

namespace MvcMeetcha.Controllers
{
    public class GroupController : Controller
    {
        private readonly MvcMeetchaContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        // Create dropdownlist for meetup type
        private void PopulateGroupTypeDropDownList(object selectedGroupType = null)
        {
            var groupTypeQuery = from gt in _context.GroupType select gt;
            ViewBag.groupTypeId = new SelectList(groupTypeQuery.AsNoTracking(), "GroupTypeId", "GroupTypeName", selectedGroupType);
        }

        public GroupController(MvcMeetchaContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Group
        public async Task<IActionResult> Index()
        {
            var group = _context.Group
                .Include(g => g.GroupType)
                .AsNoTracking();
            return View(await group.ToListAsync());
        }

        // GET: Group/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Group
                .Include(g => g.GroupType)
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.GroupId == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // GET: Group/Create
        public IActionResult Create()
        {
            PopulateGroupTypeDropDownList();
            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,GroupName,GroupDescription,GroupTypeId,GroupImageName,GroupImageFile")] Group @group)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(@group.GroupImageFile.FileName);
                string extension = Path.GetExtension(@group.GroupImageFile.FileName);
                @group.GroupImageName=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await @group.GroupImageFile.CopyToAsync(fileStream);
                }

                _context.Add(@group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateGroupTypeDropDownList(@group.GroupTypeId);
            return View(@group);
        }

        // GET: Group/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @group = await _context.Group
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.GroupId == id);
            if (@group == null)
            {
                return NotFound();
            }
            PopulateGroupTypeDropDownList(group.GroupTypeId);
            return View(@group);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var groupToUpdate = await _context.Group.FirstOrDefaultAsync(g => g.GroupId == id);

            if (await TryUpdateModelAsync<Group>(groupToUpdate,
                "", 
                g => g.GroupName,
                g => g.GroupDescription,
                g => g.GroupTypeId,
                g => g.GroupImageName))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, "+
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }

            PopulateGroupTypeDropDownList(groupToUpdate.GroupTypeId);
            return View(groupToUpdate);
        }

        // GET: Group/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Group
                .Include(g => g.GroupType)
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.GroupId == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @group = await _context.Group.FindAsync(id);

            //delete image from wwwroot/image
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", group.GroupImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            //delete record from database
            _context.Group.Remove(@group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _context.Group.Any(e => e.GroupId == id);
        }
    }
}

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
    public class MeetupController : Controller
    {
        private readonly MvcMeetchaContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        // Create dropdownlist for meetup type
        private void PopulateMeetupTypeDropDownList(object selectedMeetupType = null)
        {
            var meetupTypeQuery = from mt in _context.MeetupType select mt;
            ViewBag.meetupTypeId = new SelectList(meetupTypeQuery.AsNoTracking(), "MeetupTypeId", "MeetupTypeName", selectedMeetupType);
        }

        private void PopulateGroupDropDownList(object selectedGroup = null)
        {
            var groupQuery = from g in _context.Group select g;
            ViewBag.groupId = new SelectList(groupQuery.AsNoTracking(), "GroupId", "GroupName", selectedGroup);
        }

        public MeetupController(MvcMeetchaContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Meetup
        public async Task<IActionResult> Index()
        {
            var mvcMeetchaContext = _context.Meetup
            .Include(m => m.MeetupType)
            .Include(m => m.Group)
            .AsNoTracking();
            return View(await mvcMeetchaContext.ToListAsync());
        }

        // GET: Meetup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetup = await _context.Meetup
                .Include(m => m.MeetupType)
                .Include(m => m.Group)
                .FirstOrDefaultAsync(m => m.MeetupId == id);
            if (meetup == null)
            {
                return NotFound();
            }

            return View(meetup);
        }

        // GET: Meetup/Create
        public IActionResult Create()
        {
            ViewData["MeetupId"] = new SelectList(_context.Meetup, "MeetupId", "MeetupDescription");
            PopulateMeetupTypeDropDownList();
            PopulateGroupDropDownList();
            return View();
        }

        // POST: Meetup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetupId,MeetupName,MeetupDescription,MeetupDate,MeetupTime,MeetupTypeId,MeetupVenue,MeetupFee,MeetupImageName,MeetupImageFile,MeetupId")] Meetup meetup)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(@meetup.MeetupImageFile.FileName);
                string extension = Path.GetExtension(@meetup.MeetupImageFile.FileName);
                @meetup.MeetupImageName=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await @meetup.MeetupImageFile.CopyToAsync(fileStream);
                }

                _context.Add(meetup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateMeetupTypeDropDownList(meetup.MeetupTypeId);
            PopulateGroupDropDownList(meetup.GroupId);
            return View(meetup);
        }

        // GET: Meetup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetup = await _context.Meetup
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MeetupId == id);
            if (meetup == null)
            {
                return NotFound();
            }
            PopulateMeetupTypeDropDownList(meetup.MeetupTypeId);
            PopulateGroupDropDownList(meetup.GroupId);
            return View(meetup);
        }

        // POST: Meetup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeetupId,MeetupName,MeetupDescription,MeetupDate,MeetupTime,MeetupTypeId,MeetupVenue,MeetupFee,MeetupImageName,MeetupId")] Meetup meetup)
        {
            if (id != meetup.MeetupId)
            {
                return NotFound();
            }

            var meetupToUpdate = await _context.Meetup.FirstOrDefaultAsync(m => m.MeetupId == id);
            
            
            if (await TryUpdateModelAsync<Meetup>(meetupToUpdate,
                "", 
                m => m.MeetupName,
                m => m.MeetupDescription,
                m => m.MeetupDate,
                m => m.MeetupStartTime,
                m => m.MeetupEndTime,
                m => m.MeetupTypeId,
                m => m.MeetupVenue,
                m => m.MeetupFee,
                m => m.MeetupImageName,
                m => m.GroupId))
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
            PopulateMeetupTypeDropDownList(meetupToUpdate.MeetupTypeId);
            PopulateGroupDropDownList(meetupToUpdate.GroupId);
            return View(meetup);
        }

        // GET: Meetup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetup = await _context.Meetup
                .Include(m => m.MeetupType)
                .Include(m => m.Group)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MeetupId == id);
            if (meetup == null)
            {
                return NotFound();
            }

            return View(meetup);
        }

        // POST: Meetup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetup = await _context.Meetup.FindAsync(id);
            
            //delete image from wwwroot/image
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", meetup.MeetupImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            //delete record from database
            _context.Meetup.Remove(meetup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetupExists(int id)
        {
            return _context.Meetup.Any(e => e.MeetupId == id);
        }
    }
}

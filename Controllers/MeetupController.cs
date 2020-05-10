using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public MeetupController(MvcMeetchaContext context)
        {
            _context = context;
        }

        // GET: Meetup
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meetup.ToListAsync());
        }

        // GET: Meetup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetup = await _context.Meetup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meetup == null)
            {
                return NotFound();
            }

            return View(meetup);
        }

        // GET: Meetup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meetup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Date,StartTime,EndTime,Venue,Type,Price,Poster,VolunteersNum,AttendeesNum")] Meetup meetup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meetup);
        }

        // GET: Meetup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetup = await _context.Meetup.FindAsync(id);
            if (meetup == null)
            {
                return NotFound();
            }
            return View(meetup);
        }

        // POST: Meetup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Date,StartTime,EndTime,Venue,Type,Price,Poster,VolunteersNum,AttendeesNum")] Meetup meetup)
        {
            if (id != meetup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetupExists(meetup.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
            _context.Meetup.Remove(meetup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetupExists(int id)
        {
            return _context.Meetup.Any(e => e.Id == id);
        }
    }
}

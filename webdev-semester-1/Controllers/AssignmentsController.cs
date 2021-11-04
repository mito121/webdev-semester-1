using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webdev_semester_1.Models;

namespace webdev_semester_1.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly AlexAndersenDBContext _context;

        public AssignmentsController(AlexAndersenDBContext context)
        {
            _context = context;
        }

        // GET: Assignments
        public async Task<IActionResult> Index()
        {
            var alexAndersenDBContext = _context.Assignments.Include(a => a.Chauffeur).Include(a => a.ContactUser).Include(a => a.ReplacementUser).Include(a => a.StartCity).Include(a => a.Status);
            return View(await alexAndersenDBContext.ToListAsync());
        }

        // GET: Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Chauffeur)
                .Include(a => a.ContactUser)
                .Include(a => a.ReplacementUser)
                .Include(a => a.StartCity)
                .Include(a => a.Status)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: Assignments/Create
        public IActionResult Create()
        {
            ViewData["ChauffeurId"] = new SelectList(_context.Users, "UserId", "FirstName");
            ViewData["ContactUserId"] = new SelectList(_context.Users, "UserId", "FirstName");
            ViewData["ReplacementUserId"] = new SelectList(_context.Users, "UserId", "FirstName");
            ViewData["StartCityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusName");
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentId,StartDate,EndDate,StartTime,Urgent,AllDay,Duration,Description,CountryCodeStart,CountryCodeEnd,Available,StatusId,StartCityId,ContactUserId,ReplacementUserId,ChauffeurId")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChauffeurId"] = new SelectList(_context.Users, "UserId", "FirstName", assignment.ChauffeurId);
            ViewData["ContactUserId"] = new SelectList(_context.Users, "UserId", "FirstName", assignment.ContactUserId);
            ViewData["ReplacementUserId"] = new SelectList(_context.Users, "UserId", "FirstName", assignment.ReplacementUserId);
            ViewData["StartCityId"] = new SelectList(_context.Cities, "CityId", "CityName", assignment.StartCityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusName", assignment.StatusId);
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewData["ChauffeurId"] = new SelectList(_context.Users, "UserId", "FirstName", assignment.ChauffeurId);
            ViewData["ContactUserId"] = new SelectList(_context.Users, "UserId", "FirstName", assignment.ContactUserId);
            ViewData["ReplacementUserId"] = new SelectList(_context.Users, "UserId", "FirstName", assignment.ReplacementUserId);
            ViewData["StartCityId"] = new SelectList(_context.Cities, "CityId", "CityName", assignment.StartCityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusName", assignment.StatusId);
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentId,StartDate,EndDate,StartTime,Urgent,AllDay,Duration,Description,CountryCodeStart,CountryCodeEnd,Available,StatusId,StartCityId,ContactUserId,ReplacementUserId,ChauffeurId")] Assignment assignment)
        {
            if (id != assignment.AssignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.AssignmentId))
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
            ViewData["ChauffeurId"] = new SelectList(_context.Users, "UserId", "FirstName", assignment.ChauffeurId);
            ViewData["ContactUserId"] = new SelectList(_context.Users, "UserId", "FirstName", assignment.ContactUserId);
            ViewData["ReplacementUserId"] = new SelectList(_context.Users, "UserId", "FirstName", assignment.ReplacementUserId);
            ViewData["StartCityId"] = new SelectList(_context.Cities, "CityId", "CityName", assignment.StartCityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusName", assignment.StatusId);
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Chauffeur)
                .Include(a => a.ContactUser)
                .Include(a => a.ReplacementUser)
                .Include(a => a.StartCity)
                .Include(a => a.Status)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.AssignmentId == id);
        }
    }
}

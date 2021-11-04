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
    public class ChauffeurLicensesController : Controller
    {
        private readonly AlexAndersenDBContext _context;

        public ChauffeurLicensesController(AlexAndersenDBContext context)
        {
            _context = context;
        }

        // GET: ChauffeurLicenses
        public async Task<IActionResult> Index()
        {
            var alexAndersenDBContext = _context.ChauffeurLicenses.Include(c => c.Chauffeur).Include(c => c.Type);
            return View(await alexAndersenDBContext.ToListAsync());
        }

        // GET: ChauffeurLicenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chauffeurLicense = await _context.ChauffeurLicenses
                .Include(c => c.Chauffeur)
                .Include(c => c.Type)
                .FirstOrDefaultAsync(m => m.ChauffeurId == id);
            if (chauffeurLicense == null)
            {
                return NotFound();
            }

            return View(chauffeurLicense);
        }

        // GET: ChauffeurLicenses/Create
        public IActionResult Create()
        {
            ViewData["ChauffeurId"] = new SelectList(_context.Users, "UserId", "FirstName");
            ViewData["TypeId"] = new SelectList(_context.LicenseTypes, "TypeId", "TypeName");
            return View();
        }

        // POST: ChauffeurLicenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChauffeurId,TypeId")] ChauffeurLicense chauffeurLicense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chauffeurLicense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChauffeurId"] = new SelectList(_context.Users, "UserId", "FirstName", chauffeurLicense.ChauffeurId);
            ViewData["TypeId"] = new SelectList(_context.LicenseTypes, "TypeId", "TypeName", chauffeurLicense.TypeId);
            return View(chauffeurLicense);
        }

        // GET: ChauffeurLicenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chauffeurLicense = await _context.ChauffeurLicenses.FindAsync(id);
            if (chauffeurLicense == null)
            {
                return NotFound();
            }
            ViewData["ChauffeurId"] = new SelectList(_context.Users, "UserId", "FirstName", chauffeurLicense.ChauffeurId);
            ViewData["TypeId"] = new SelectList(_context.LicenseTypes, "TypeId", "TypeName", chauffeurLicense.TypeId);
            return View(chauffeurLicense);
        }

        // POST: ChauffeurLicenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChauffeurId,TypeId")] ChauffeurLicense chauffeurLicense)
        {
            if (id != chauffeurLicense.ChauffeurId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chauffeurLicense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChauffeurLicenseExists(chauffeurLicense.ChauffeurId))
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
            ViewData["ChauffeurId"] = new SelectList(_context.Users, "UserId", "FirstName", chauffeurLicense.ChauffeurId);
            ViewData["TypeId"] = new SelectList(_context.LicenseTypes, "TypeId", "TypeName", chauffeurLicense.TypeId);
            return View(chauffeurLicense);
        }

        // GET: ChauffeurLicenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chauffeurLicense = await _context.ChauffeurLicenses
                .Include(c => c.Chauffeur)
                .Include(c => c.Type)
                .FirstOrDefaultAsync(m => m.ChauffeurId == id);
            if (chauffeurLicense == null)
            {
                return NotFound();
            }

            return View(chauffeurLicense);
        }

        // POST: ChauffeurLicenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chauffeurLicense = await _context.ChauffeurLicenses.FindAsync(id);
            _context.ChauffeurLicenses.Remove(chauffeurLicense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChauffeurLicenseExists(int id)
        {
            return _context.ChauffeurLicenses.Any(e => e.ChauffeurId == id);
        }
    }
}

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
    public class LicenseTypesController : Controller
    {
        private readonly AlexAndersenDBContext _context;

        public LicenseTypesController(AlexAndersenDBContext context)
        {
            _context = context;
        }

        // GET: LicenseTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LicenseTypes.ToListAsync());
        }

        // GET: LicenseTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseType = await _context.LicenseTypes
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (licenseType == null)
            {
                return NotFound();
            }

            return View(licenseType);
        }

        // GET: LicenseTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LicenseTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,TypeName")] LicenseType licenseType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(licenseType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(licenseType);
        }

        // GET: LicenseTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseType = await _context.LicenseTypes.FindAsync(id);
            if (licenseType == null)
            {
                return NotFound();
            }
            return View(licenseType);
        }

        // POST: LicenseTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,TypeName")] LicenseType licenseType)
        {
            if (id != licenseType.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licenseType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenseTypeExists(licenseType.TypeId))
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
            return View(licenseType);
        }

        // GET: LicenseTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseType = await _context.LicenseTypes
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (licenseType == null)
            {
                return NotFound();
            }

            return View(licenseType);
        }

        // POST: LicenseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licenseType = await _context.LicenseTypes.FindAsync(id);
            _context.LicenseTypes.Remove(licenseType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicenseTypeExists(int id)
        {
            return _context.LicenseTypes.Any(e => e.TypeId == id);
        }
    }
}

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
    public class ChauffeurInfoesController : Controller
    {
        private readonly AlexAndersenDBContext _context;

        public ChauffeurInfoesController(AlexAndersenDBContext context)
        {
            _context = context;
        }

        // GET: ChauffeurInfoes
        public async Task<IActionResult> Index()
        {
            var alexAndersenDBContext = _context.ChauffeurInfos.Include(c => c.Type);
            return View(await alexAndersenDBContext.ToListAsync());
        }

        // GET: ChauffeurInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chauffeurInfo = await _context.ChauffeurInfos
                .Include(c => c.Type)
                .FirstOrDefaultAsync(m => m.ChauffeurInfoId == id);
            if (chauffeurInfo == null)
            {
                return NotFound();
            }

            return View(chauffeurInfo);
        }

        // GET: ChauffeurInfoes/Create
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(_context.LicenseTypes, "TypeId", "TypeName");
            return View();
        }

        // POST: ChauffeurInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChauffeurInfoId,RouteType,DriverLicenseNo,DriverLicenseExperationDate,DriverLicenseImage,TruckLicense,TruckLicenseExperationDate,TruckLicenseImage,EuQualification,EuQualificationExperationDate,TypeId")] ChauffeurInfo chauffeurInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chauffeurInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_context.LicenseTypes, "TypeId", "TypeName", chauffeurInfo.TypeId);
            return View(chauffeurInfo);
        }

        // GET: ChauffeurInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chauffeurInfo = await _context.ChauffeurInfos.FindAsync(id);
            if (chauffeurInfo == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.LicenseTypes, "TypeId", "TypeName", chauffeurInfo.TypeId);
            return View(chauffeurInfo);
        }

        // POST: ChauffeurInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChauffeurInfoId,RouteType,DriverLicenseNo,DriverLicenseExperationDate,DriverLicenseImage,TruckLicense,TruckLicenseExperationDate,TruckLicenseImage,EuQualification,EuQualificationExperationDate,TypeId")] ChauffeurInfo chauffeurInfo)
        {
            if (id != chauffeurInfo.ChauffeurInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chauffeurInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChauffeurInfoExists(chauffeurInfo.ChauffeurInfoId))
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
            ViewData["TypeId"] = new SelectList(_context.LicenseTypes, "TypeId", "TypeName", chauffeurInfo.TypeId);
            return View(chauffeurInfo);
        }

        // GET: ChauffeurInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chauffeurInfo = await _context.ChauffeurInfos
                .Include(c => c.Type)
                .FirstOrDefaultAsync(m => m.ChauffeurInfoId == id);
            if (chauffeurInfo == null)
            {
                return NotFound();
            }

            return View(chauffeurInfo);
        }

        // POST: ChauffeurInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chauffeurInfo = await _context.ChauffeurInfos.FindAsync(id);
            _context.ChauffeurInfos.Remove(chauffeurInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChauffeurInfoExists(int id)
        {
            return _context.ChauffeurInfos.Any(e => e.ChauffeurInfoId == id);
        }
    }
}

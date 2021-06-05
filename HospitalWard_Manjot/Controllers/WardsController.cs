using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalWard_Manjot.Data;
using HospitalWard_Manjot.Models;
using Microsoft.AspNetCore.Authorization;

namespace HospitalWard_Manjot.Controllers
{
    [Authorize]
    public class WardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wards
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Wards.Include(w => w.Doctor).Include(w => w.Nurse);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Wards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ward = await _context.Wards
                .Include(w => w.Doctor)
                .Include(w => w.Nurse)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ward == null)
            {
                return NotFound();
            }

            return View(ward);
        }

        // GET: Wards/Create
        public IActionResult Create()
        {
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "ID", "DoctorName");
            ViewData["NurseID"] = new SelectList(_context.Nurses, "ID", "NurseName");
            return View();
        }

        // POST: Wards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Location,NurseID,DoctorID")] Ward ward)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ward);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "ID", "DoctorName", ward.DoctorID);
            ViewData["NurseID"] = new SelectList(_context.Nurses, "ID", "NurseName", ward.NurseID);
            return View(ward);
        }

        // GET: Wards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ward = await _context.Wards.FindAsync(id);
            if (ward == null)
            {
                return NotFound();
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "ID", "DoctorName", ward.DoctorID);
            ViewData["NurseID"] = new SelectList(_context.Nurses, "ID", "NurseName", ward.NurseID);
            return View(ward);
        }

        // POST: Wards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Location,NurseID,DoctorID")] Ward ward)
        {
            if (id != ward.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ward);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WardExists(ward.ID))
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
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "ID", "DoctorName", ward.DoctorID);
            ViewData["NurseID"] = new SelectList(_context.Nurses, "ID", "NurseName", ward.NurseID);
            return View(ward);
        }

        // GET: Wards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ward = await _context.Wards
                .Include(w => w.Doctor)
                .Include(w => w.Nurse)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ward == null)
            {
                return NotFound();
            }

            return View(ward);
        }

        // POST: Wards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ward = await _context.Wards.FindAsync(id);
            _context.Wards.Remove(ward);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WardExists(int id)
        {
            return _context.Wards.Any(e => e.ID == id);
        }
    }
}

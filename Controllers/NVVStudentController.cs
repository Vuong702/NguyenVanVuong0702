using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenVanVuong0702.Models;

namespace NguyenVanVuong0702.Controllers
{
    public class NVVStudentController : Controller
    {
        private readonly BAITHI _context;

        public NVVStudentController(BAITHI context)
        {
            _context = context;
        }

        // GET: NVVStudent
        public async Task<IActionResult> Index()
        {
              return _context.NVVStudent != null ? 
                          View(await _context.NVVStudent.ToListAsync()) :
                          Problem("Entity set 'BAITHI.NVVStudent'  is null.");
        }

        // GET: NVVStudent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NVVStudent == null)
            {
                return NotFound();
            }

            var nVVStudent = await _context.NVVStudent
                .FirstOrDefaultAsync(m => m.MaSinhVien == id);
            if (nVVStudent == null)
            {
                return NotFound();
            }

            return View(nVVStudent);
        }

        // GET: NVVStudent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NVVStudent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSinhVien,TenSinhVien")] NVVStudent nVVStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nVVStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nVVStudent);
        }

        // GET: NVVStudent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NVVStudent == null)
            {
                return NotFound();
            }

            var nVVStudent = await _context.NVVStudent.FindAsync(id);
            if (nVVStudent == null)
            {
                return NotFound();
            }
            return View(nVVStudent);
        }

        // POST: NVVStudent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSinhVien,TenSinhVien")] NVVStudent nVVStudent)
        {
            if (id != nVVStudent.MaSinhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nVVStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NVVStudentExists(nVVStudent.MaSinhVien))
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
            return View(nVVStudent);
        }

        // GET: NVVStudent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NVVStudent == null)
            {
                return NotFound();
            }

            var nVVStudent = await _context.NVVStudent
                .FirstOrDefaultAsync(m => m.MaSinhVien == id);
            if (nVVStudent == null)
            {
                return NotFound();
            }

            return View(nVVStudent);
        }

        // POST: NVVStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NVVStudent == null)
            {
                return Problem("Entity set 'BAITHI.NVVStudent'  is null.");
            }
            var nVVStudent = await _context.NVVStudent.FindAsync(id);
            if (nVVStudent != null)
            {
                _context.NVVStudent.Remove(nVVStudent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NVVStudentExists(int id)
        {
          return (_context.NVVStudent?.Any(e => e.MaSinhVien == id)).GetValueOrDefault();
        }
    }
}

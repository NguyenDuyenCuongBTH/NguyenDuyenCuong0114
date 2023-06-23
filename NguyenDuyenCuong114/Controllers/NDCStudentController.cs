using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenDuyenCuong114;

namespace NguyenDuyenCuong114.Controllers
{
    public class NDCStudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NDCStudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NDCStudent
        public async Task<IActionResult> Index()
        {
              return _context.NDCStudent != null ? 
                          View(await _context.NDCStudent.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NDCStudent'  is null.");
        }

        // GET: NDCStudent/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NDCStudent == null)
            {
                return NotFound();
            }

            var nDCStudent = await _context.NDCStudent
                .FirstOrDefaultAsync(m => m.NDCStudentID == id);
            if (nDCStudent == null)
            {
                return NotFound();
            }

            return View(nDCStudent);
        }

        // GET: NDCStudent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NDCStudent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NDCStudentID,NDCStudentName,Sdt")] NDCStudent nDCStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nDCStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nDCStudent);
        }

        // GET: NDCStudent/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NDCStudent == null)
            {
                return NotFound();
            }

            var nDCStudent = await _context.NDCStudent.FindAsync(id);
            if (nDCStudent == null)
            {
                return NotFound();
            }
            return View(nDCStudent);
        }

        // POST: NDCStudent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NDCStudentID,NDCStudentName,Sdt")] NDCStudent nDCStudent)
        {
            if (id != nDCStudent.NDCStudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nDCStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NDCStudentExists(nDCStudent.NDCStudentID))
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
            return View(nDCStudent);
        }

        // GET: NDCStudent/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NDCStudent == null)
            {
                return NotFound();
            }

            var nDCStudent = await _context.NDCStudent
                .FirstOrDefaultAsync(m => m.NDCStudentID == id);
            if (nDCStudent == null)
            {
                return NotFound();
            }

            return View(nDCStudent);
        }

        // POST: NDCStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NDCStudent == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NDCStudent'  is null.");
            }
            var nDCStudent = await _context.NDCStudent.FindAsync(id);
            if (nDCStudent != null)
            {
                _context.NDCStudent.Remove(nDCStudent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NDCStudentExists(string id)
        {
          return (_context.NDCStudent?.Any(e => e.NDCStudentID == id)).GetValueOrDefault();
        }
    }
}

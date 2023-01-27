using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcEmployee.Data;
using MvcEmployee.Models;

namespace MvcEmployee.Controllers
{
    public class QualificationController : Controller
    {
        private readonly MvcEmployeeContext _context;

        public QualificationController(MvcEmployeeContext context)
        {
            _context = context;
        }

        // GET: Qualification
        public async Task<IActionResult> Index()
        {
            var mvcEmployeeContext = _context.Qualification.Include(q => q.Employee).Include(q => q.QualificationList);
            return View(await mvcEmployeeContext.ToListAsync());
        }

        // GET: Qualification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Qualification == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualification
                .Include(q => q.Employee)
                .Include(q => q.QualificationList)
                .FirstOrDefaultAsync(m => m.QualificationId == id);
            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);
        }

        // GET: Qualification/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Name");
            ViewData["QualificationListId"] = new SelectList(_context.QualificationList, "QualificationListId", "QualificationListId");
            return View();
        }

        // POST: Qualification/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QualificationId,Marks,EmployeeId,QualificationListId")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Name", qualification.EmployeeId);
            ViewData["QualificationListId"] = new SelectList(_context.QualificationList, "QualificationListId", "QualificationListId", qualification.QualificationListId);
            return View(qualification);
        }

        // GET: Qualification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Qualification == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualification.FindAsync(id);
            if (qualification == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Name", qualification.EmployeeId);
            ViewData["QualificationListId"] = new SelectList(_context.QualificationList, "QualificationListId", "QualificationListId", qualification.QualificationListId);
            return View(qualification);
        }

        // POST: Qualification/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QualificationId,Marks,EmployeeId,QualificationListId")] Qualification qualification)
        {
            if (id != qualification.QualificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qualification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualificationExists(qualification.QualificationId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Name", qualification.EmployeeId);
            ViewData["QualificationListId"] = new SelectList(_context.QualificationList, "QualificationListId", "QualificationListId", qualification.QualificationListId);
            return View(qualification);
        }

        // GET: Qualification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Qualification == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualification
                .Include(q => q.Employee)
                .Include(q => q.QualificationList)
                .FirstOrDefaultAsync(m => m.QualificationId == id);
            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);
        }

        // POST: Qualification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Qualification == null)
            {
                return Problem("Entity set 'MvcEmployeeContext.Qualification'  is null.");
            }
            var qualification = await _context.Qualification.FindAsync(id);
            if (qualification != null)
            {
                _context.Qualification.Remove(qualification);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QualificationExists(int id)
        {
          return (_context.Qualification?.Any(e => e.QualificationId == id)).GetValueOrDefault();
        }
    }
}

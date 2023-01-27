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
    public class QualificationListController : Controller
    {
        private readonly MvcEmployeeContext _context;

        public QualificationListController(MvcEmployeeContext context)
        {
            _context = context;
        }

        // GET: QualificationList
        public async Task<IActionResult> Index()
        {
              return _context.QualificationList != null ? 
                          View(await _context.QualificationList.ToListAsync()) :
                          Problem("Entity set 'MvcEmployeeContext.QualificationList'  is null.");
        }

        // GET: QualificationList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QualificationList == null)
            {
                return NotFound();
            }

            var qualificationList = await _context.QualificationList
                .FirstOrDefaultAsync(m => m.QualificationListId == id);
            if (qualificationList == null)
            {
                return NotFound();
            }

            return View(qualificationList);
        }

        // GET: QualificationList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QualificationList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QualificationListId,Name")] QualificationList qualificationList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualificationList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qualificationList);
        }

        // GET: QualificationList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QualificationList == null)
            {
                return NotFound();
            }

            var qualificationList = await _context.QualificationList.FindAsync(id);
            if (qualificationList == null)
            {
                return NotFound();
            }
            return View(qualificationList);
        }

        // POST: QualificationList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QualificationListId,Name")] QualificationList qualificationList)
        {
            if (id != qualificationList.QualificationListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qualificationList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualificationListExists(qualificationList.QualificationListId))
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
            return View(qualificationList);
        }

        // GET: QualificationList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QualificationList == null)
            {
                return NotFound();
            }

            var qualificationList = await _context.QualificationList
                .FirstOrDefaultAsync(m => m.QualificationListId == id);
            if (qualificationList == null)
            {
                return NotFound();
            }

            return View(qualificationList);
        }

        // POST: QualificationList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QualificationList == null)
            {
                return Problem("Entity set 'MvcEmployeeContext.QualificationList'  is null.");
            }
            var qualificationList = await _context.QualificationList.FindAsync(id);
            if (qualificationList != null)
            {
                _context.QualificationList.Remove(qualificationList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QualificationListExists(int id)
        {
          return (_context.QualificationList?.Any(e => e.QualificationListId == id)).GetValueOrDefault();
        }
    }
}

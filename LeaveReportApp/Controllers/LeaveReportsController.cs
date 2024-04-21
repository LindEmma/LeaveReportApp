using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveReportApp.Data;
using LeaveReportApp.Models;
using LeaveReportApp.Data.Enum;
using System.Globalization;

namespace LeaveReportApp.Controllers
{
    public class LeaveReportsController : Controller
    {
        private readonly LeaveReportDbContext _context;

        public LeaveReportsController(LeaveReportDbContext context)
        {
            _context = context;
        }

        // GET: LeaveReports
        public async Task<IActionResult> Index(string searchString, LeaveType type, int? selectedMonth)
        {

            if (_context.LeaveReports == null)
            {
                return Problem("Entity set 'LeaveReportsApp.LeaveReport'  is null.");
            }

            IQueryable<LeaveType> reportQuery = from l in _context.LeaveReports
                                                orderby l.LeaveType
                                                select l.LeaveType;

            var lR = from l in _context.LeaveReports
                     .Include(e => e.Employee)
                     select l;


            if (!String.IsNullOrEmpty(searchString))
            {
                lR = lR.Where(s => s.Employee!.FirstName.Contains(searchString));
            }
            if (type != null)
            {
                lR = lR.Where(x => x.LeaveType == type);
            }
            if (selectedMonth.HasValue)
            {
                lR = lR.Where(x => x.LeaveReportDate.Month == selectedMonth.Value);
            }

            var monthsList = Enum.GetValues(typeof(Months)).Cast<Months>().Select(m => new SelectListItem
            {
                Text = m.ToString(),
                Value = ((int)m+1).ToString()
            });

            var leaveTypeReportVM = new LeaveTypeReportViewModel
            {
                LeaveTypes = new SelectList(await reportQuery.Distinct().ToListAsync()),
                LeaveReports = await lR.ToListAsync(),
                Months = new SelectList(monthsList, "Value", "Text", selectedMonth)
            };

            return View(leaveTypeReportVM);
        }


        // GET: LeaveReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveReport = await _context.LeaveReports
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.LeaveReportId == id);

            if (leaveReport == null)
            {
                return NotFound();
            }

            return View(leaveReport);
        }

        // GET: LeaveReports/Create
        public IActionResult Create()
        {
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmpId", "FirstName");
            return View();
        }

        // POST: LeaveReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveReportId,StartDate,EndDate,LeaveReportDate,LeaveType,FkEmployeeId")] LeaveReport leaveReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmpId", "FirstName", leaveReport.FkEmployeeId);
            return View(leaveReport);
        }

        // GET: LeaveReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveReport = await _context.LeaveReports.FindAsync(id);
            if (leaveReport == null)
            {
                return NotFound();
            }
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmpId", "FirstName", leaveReport.FkEmployeeId);
            return View(leaveReport);
        }

        // POST: LeaveReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaveReportId,StartDate,EndDate,LeaveReportDate,LeaveType,FkEmployeeId")] LeaveReport leaveReport)
        {
            if (id != leaveReport.LeaveReportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveReportExists(leaveReport.LeaveReportId))
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
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmpId", "FirstName", leaveReport.FkEmployeeId);
            return View(leaveReport);
        }

        // GET: LeaveReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveReport = await _context.LeaveReports
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.LeaveReportId == id);
            if (leaveReport == null)
            {
                return NotFound();
            }

            return View(leaveReport);
        }

        // POST: LeaveReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveReport = await _context.LeaveReports.FindAsync(id);
            if (leaveReport != null)
            {
                _context.LeaveReports.Remove(leaveReport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveReportExists(int id)
        {
            return _context.LeaveReports.Any(e => e.LeaveReportId == id);
        }
    }
}

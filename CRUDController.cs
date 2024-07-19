using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject.DBContext;
using MVCProject.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVCProject.Controllers
{
    public class CRUDController : Controller
    {
        private readonly MyDbContext _context;

        public CRUDController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employee.Include(e => e.Designation).ToListAsync();
            return View(employees);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employee.Include(e => e.Designation).FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        public IActionResult Create()
        {
            ViewData["DesignationIdRef"] = new SelectList(_context.Designation, "DesignationIdRef", "DesignationName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailAddress,PhoneNumber,DesignationIdRef")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DesignationIdRef"] = new SelectList(_context.Designation, "DesignationIdRef", "DesignationName", employee.DesignationIdRef);
            return View(employee);
        }
        //public IActionResult Create()
        //{
        //    ViewData["DesignationIdRef"] = new SelectList(_context.Designation, "DesignationIdRef", "DesignationName");
        //    ViewData["GradeIdRef"] = new SelectList(_context.DesignationGrade, "GradeIdRef", "GradeName");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailAddress,PhoneNumber,DesignationIdRef,GradeIdRef")] Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Add(employee);
        //            await _context.SaveChangesAsync();
        //            TempData["SuccessMessage"] = "Data Added Successfully";
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (Exception ex)
        //        {
        //            TempData["ErrorMessage"] = $"An error occurred while saving the data: {ex.Message}";
        //            return RedirectToAction(nameof(Error));
        //        }
        //    }

        //    ViewData["DesignationIdRef"] = new SelectList(_context.Designation, "DesignationIdRef", "DesignationName", employee.DesignationIdRef);
        //    ViewData["GradeIdRef"] = new SelectList(_context.DesignationGrade, "GradeIdRef", "GradeName", employee.GradeIdRef);
        //    return View(employee);
        //}

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null) return NotFound();

            ViewData["DesignationIdRef"] = new SelectList(_context.Designation, "DesignationIdRef", "DesignationName", employee.DesignationIdRef);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,EmailAddress,PhoneNumber,DesignationIdRef")] Employee employee)
        {
            if (id != employee.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DesignationIdRef"] = new SelectList(_context.Designation, "DesignationIdRef", "DesignationName", employee.DesignationIdRef);
            return View(employee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employee.Include(e => e.Designation).FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null) _context.Employee.Remove(employee);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id) => _context.Employee.Any(e => e.Id == id);
    }
}

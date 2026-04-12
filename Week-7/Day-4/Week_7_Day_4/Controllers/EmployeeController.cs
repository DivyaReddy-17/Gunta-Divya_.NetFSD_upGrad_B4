using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week_7_Day_4.Data;
using Week_7_Day_4.Models;

namespace Week_7_Day_4.Controllers
{
    public class EmployeeController : Controller
    {
        
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // ========== INDEX / READ ==========
        public async Task<IActionResult> Index(
            string search,
            string department,
            string sortOrder,
            DateTime? startDate,
            DateTime? endDate)
        {
            var employees = _context.employees.AsQueryable();

            //  Search
            if (!string.IsNullOrEmpty(search))
            {
                employees = employees.Where(e => e.Name.Contains(search));
            }

            //  Filter by Department
            if (!string.IsNullOrEmpty(department))
            {
                employees = employees.Where(e => e.Department == department);
            }

            //  Date Range Filter
            if (startDate.HasValue && endDate.HasValue)
            {
                employees = employees.Where(e =>
                    e.HireDate >= startDate.Value &&
                    e.HireDate <= endDate.Value);
            }

            //  Sorting
            employees = sortOrder == "desc"
                ? employees.OrderByDescending(e => e.Salary)
                : employees.OrderBy(e => e.Salary);


            ViewBag.Search = search;
            ViewBag.Department = department;
            ViewBag.SortOrder = sortOrder;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            return View(await employees.ToListAsync());
        }

        // ========== CREATE ==========
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        // ========== EDIT ==========
        public async Task<IActionResult> Edit(int id)
        {
            var emp = await _context.employees.FindAsync(id);
            if (emp == null)
                return NotFound();

            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Update(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        // ========== DELETE ==========
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _context.employees.FindAsync(id);
            if (emp == null)
                return NotFound();

            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emp = await _context.employees.FindAsync(id);

            if (emp != null)
            {
                _context.Remove(emp);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // ========== REPORTS (LINQ) ==========
        public IActionResult Reports()
        {
            // Total Employees
            var totalEmployees = _context.employees.Count();

            // Average Salary by Department
            var avgSalaryDept = _context.employees
                .GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    AvgSalary = g.Average(e => e.Salary)
                }).ToList();

            // Highest Paid Employee
            var highestPaid = _context.employees
                .OrderByDescending(e => e.Salary)
                .FirstOrDefault();

            // Grouped Employees
            var grouped = _context.employees
                .GroupBy(e => e.Department)
                .ToList();

            ViewBag.Total = totalEmployees;
            ViewBag.AvgSalary = avgSalaryDept;
            ViewBag.Highest = highestPaid;
            ViewBag.Grouped = grouped;

            return View();
        }
    }
}




using Microsoft.AspNetCore.Mvc;
using CFDB_practice;
using CFDB_practice.Models;

namespace CFDB_practice.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MyContext _context;
        public EmployeeController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
        public IActionResult Details(int id)
        {
            var employees = _context.Employees.FirstOrDefault(x => x.EmpId == id);
            return View(employees);
        }
        public IActionResult Edit(int id)
        {
            var employees = _context.Employees.FirstOrDefault(x => x.EmpId == id);

            return View(employees);


        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (employee != null)
            {
                _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.EmpId == id);
            return View(employee);
        }
        [HttpPost("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.EmpId == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}


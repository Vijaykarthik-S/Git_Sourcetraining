using CFDB_practice.Models;
using Microsoft.AspNetCore.Mvc;


namespace CFDB_practice.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MyContext _context;
        public DepartmentController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var departments = _context.Department.ToList();
            return View(departments);
        }
        public IActionResult Details(int id)
        {
            var departments = _context.Department.FirstOrDefault(x => x.Id == id);
            return View(departments);
        }
        public IActionResult Edit(int id)
        {
            var departments = _context.Department.FirstOrDefault(x => x.Id == id);

            return View(departments);


        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (department != null)
            {
                _context.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Department.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var department = _context.Department.FirstOrDefault(x => x.Id == id);
            return View(department);
        }
        [HttpPost("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _context.Department.FirstOrDefault(x => x.Id == id);
            if (department != null)
            {
                _context.Department.Remove(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly List<Employee> _employees;

        public EmployeeController()
        {
            // Sample data for demonstration purposes
            _employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John Doe", Designation = "Software Engineer", Department = "IT" },
                new Employee { Id = 2, Name = "Jane Doe", Designation = "Data Scientist", Department = "Data Science" },
                new Employee { Id = 3, Name = "Bob Smith", Designation = "Project Manager", Department = "Project Management" }
            };
        }

        public IActionResult Index()
        {
            return View(_employees);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employees.Find(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Designation,Department")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Simulate adding the new employee to the data source (in-memory list)
                employee.Id = _employees.Count + 1;
                _employees.Add(employee);
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employees.Find(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Designation,Department")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Simulate updating the employee in the data source (in-memory list)
                var index = _employees.FindIndex(e => e.Id == id);
                _employees[index] = employee;
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employees.Find(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Simulate deleting the employee from the data source (in-memory list)
            var employee = _employees.Find(e => e.Id == id);
            _employees.Remove(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}

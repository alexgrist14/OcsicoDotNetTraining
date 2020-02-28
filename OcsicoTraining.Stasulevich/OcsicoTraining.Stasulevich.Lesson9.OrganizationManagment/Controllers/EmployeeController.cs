using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagment.ViewModels;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson9.OrganizationManagment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await employeeService.GetAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var employee = await employeeService.GetAsync(id);

            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeViewModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                await employeeService.CreateAsync(employeeModel);
                return RedirectToAction(nameof(Index));
            }
            return View(employeeModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await employeeService.GetAsync(id);

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await employeeService.UpdateAsync(employee);

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await employeeService.GetAsync(id);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, Employee employee)
        {
            await employeeService.RemoveAsync(employee);

            return RedirectToAction(nameof(Index));
        }
    }
}

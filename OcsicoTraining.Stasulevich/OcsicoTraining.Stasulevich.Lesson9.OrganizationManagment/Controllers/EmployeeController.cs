using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagment.ViewModels;
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
        public async Task<IActionResult> Create(EmployeeViewModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                await employeeService.CreateAsync(employeeModel);
                return RedirectToAction(nameof(Index));
            }

            return View(employeeModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await employeeService.GetAsync(id);

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                await employeeService.UpdateAsync(employee);

                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await employeeService.GetAsync(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, EmployeeViewModel employee)
        {
            await employeeService.RemoveAsync(employee);

            return RedirectToAction(nameof(Index));
        }
    }
}

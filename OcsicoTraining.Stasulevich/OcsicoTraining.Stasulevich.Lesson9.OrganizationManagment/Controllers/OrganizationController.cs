using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.ViewModels;

namespace OcsicoTraining.Stasulevich.Lesson9.OrganizationManagment.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService organizationService;
        private readonly IEmployeeService employeeService;
        private readonly IRoleService roleService;

        public OrganizationController(IOrganizationService organizationService,
            IEmployeeService employeeService,
            IRoleService roleService)
        {
            this.organizationService = organizationService;
            this.employeeService = employeeService;
            this.roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var organizations = await organizationService.GetAsync();
            return View(organizations);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var organization = await organizationService.GetAsync(id);

            return View(organization);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrganizationViewModel organizationModel)
        {
            if (ModelState.IsValid)
            {
                await organizationService.CreateAsync(organizationModel);
                return RedirectToAction(nameof(Index));
            }
            return View(organizationModel);
        }

        [HttpPost]
        public async Task<IActionResult> Employees(Guid organizationId)
        {
            var employees = await organizationService.GetEmployeesAsync(organizationId);

            return View(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveEmployee(RemoveEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await organizationService.RemoveEmployeeAsync(model);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.ViewModels;

namespace OcsicoTraining.Stasulevich.Lesson9.OrganizationManagment.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await roleService.GetAsync();

            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var role = await roleService.GetViewModelAsync(id);

            return View(role);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                await roleService.CreateAsync(roleModel);
                return RedirectToAction(nameof(Index));
            }

            return View(roleModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var role = await roleService.GetViewModelAsync(id);

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                await roleService.UpdateAsync(role);

                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var role = await roleService.GetViewModelAsync(id);

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, RoleViewModel role)
        {
            await roleService.RemoveAsync(role);

            return RedirectToAction(nameof(Index));
        }
    }
}

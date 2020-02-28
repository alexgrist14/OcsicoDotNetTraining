using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem;
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
            var role = await roleService.GetAsync(id);

            return View(role);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRoleViewModel roleModel)
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
            var role = await roleService.GetAsync(id);

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Role role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await roleService.UpdateAsync(role);

                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var role = await roleService.GetAsync(id);
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, Role role)
        {
            await roleService.RemoveAsync(role);

            return RedirectToAction(nameof(Index));
        }
    }
}

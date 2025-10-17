using CoreMVC_Identity.Areas.Identity.Data;
using CoreMVC_Identity.Data;
using CoreMVC_Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVC_Identity.Controllers
{
    //[Authorize(Roles = "Admin")]
    //[Authorize(Policy = "ClaimPolicy")]
    [ClaimCheck(ClaimType = "Position", ClaimValue = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // GET: Administration
        public ActionResult Index()
        {
            var viewModel = new AdministrationFormViewModel
            {
                Roles = _roleManager.Roles.ToList(),        // получить список ролей
                Users = _context.Users.ToList()             // получить список пользователей
            };

            return View(viewModel);
        }

        // GET: /Administration/New
        [HttpGet, ActionName("New")]
        public async Task<ActionResult> NewUser()
        {
            // Создание нового пользователя

            var user = new ApplicationUser()
            {
                Email = "ivanchik@mail.com",
                UserName = "Ivan",
                FirstName = "Ivan",
                LastName = "Petrov"
            };

            await _userManager.CreateAsync(user, "Aa_1234567");

            return RedirectToAction("Index");
        }

        // GET: /Administration/New
        [HttpGet, ActionName("NewRole")]
        public async Task<ActionResult> CreateNewRole()
        {
            // Создание новой роли
            await _roleManager.CreateAsync(new IdentityRole("ContentManager"));

            return RedirectToAction("Index");
        }

        // GET: /Administration/DeleteRole/1
        [HttpGet, ActionName("DeleteRole")]
        public async Task<ActionResult> DeleteRoleConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new NotFoundResult();
                }

                // Удаление роли
                var role = await _roleManager.FindByIdAsync(id);
                await _roleManager.DeleteAsync(role);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        // GET: /Administration/Delete/5
        [HttpGet, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new NotFoundResult();
                }

                // Удаление пользователя
                var user = await _userManager.FindByIdAsync(id);
                var logins = await _userManager.GetLoginsAsync(user);
                var rolesForUser = await _userManager.GetRolesAsync(user);

                // Открытие транзакции для комплексного удаления
                using (var transaction = _context.Database.BeginTransaction())
                {
                    // Удалить логин пользователя
                    foreach (var login in logins.ToList())
                    {
                        await _userManager.RemoveLoginAsync(user, login.LoginProvider, login.ProviderKey);
                    }

                    // Удалить пользователя из ролей
                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            // item should be the name of the role
                            var result = await _userManager.RemoveFromRoleAsync(user, item);
                        }
                    }

                    // Удаление пользователя
                    await _userManager.DeleteAsync(user);

                    // Фиксация транзакции удаления
                    transaction.Commit();
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}

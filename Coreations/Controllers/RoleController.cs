using COREationsTask.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace COREationsTask.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleDto role)
        {
            if(ModelState.IsValid)
            {
                IdentityRole roleIdentity = new IdentityRole() { Name = role.RoleName };
                IdentityResult result=  await _roleManager.CreateAsync(roleIdentity);
                if(result.Succeeded)
                {
                    return View();
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View(role);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

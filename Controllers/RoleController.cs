using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Controllers
{
    [Authorize(Policy ="readpolicy")]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [Authorize(Policy ="readpolicy")]
        public IActionResult Index()
        {
            var roles = this.roleManager.Roles.ToList();
            return this.View(roles);
        }

        [Authorize (Policy = "readpolicy")]
        public IActionResult Create()
        {
            return this.View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await this.roleManager.CreateAsync(role);
            return this.RedirectToAction("Index");
        }
    }
}

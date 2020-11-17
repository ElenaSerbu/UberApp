using Auth.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Controllers
{
    [Authorize(Policy ="readpolicy")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext context;

        public AdminController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this._userManager = userManager;
            this.context = context;
        }

        [Authorize(Policy ="readpolicy")]
        public async Task<IActionResult> Index()
        {
             var users = this._userManager.Users.ToList();
            var userNames = new List<string>();
            foreach (var u in users)
            {
                var roles = await this._userManager.GetRolesAsync(u);
                foreach (var role in roles)
                {
                    if (role.Equals("Account"))
                    {
                        userNames.Add(u.UserName);
                    }
                }
            }
            return this.View(userNames);
        }

        [Authorize(Policy = "readpolicy")]
        public ActionResult Create()
        {
            return this.Redirect("https://localhost:44325/Identity/Account/Register");
        }
        
        [Authorize(Policy = "readpolicy")]
        public async Task<ActionResult> Delete(string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                var user = this._userManager.Users.ToList().FirstOrDefault(u => u.UserName.Equals(userName));
                var rolesForUser = await this._userManager.GetRolesAsync(user);

                using (var transaction = this.context.Database.BeginTransaction())
                {
                    if (rolesForUser.Count() > 0)
                    {
                        foreach(var item in rolesForUser)
                        {
                            var result = await this._userManager.RemoveFromRoleAsync(user, item);
                        }
                    }

                    await this._userManager.DeleteAsync(user);
                    transaction.Commit();
                }

                return this.Redirect("https://localhost:44325/admin");
            }

            return this.NotFound();
        }
    }
}

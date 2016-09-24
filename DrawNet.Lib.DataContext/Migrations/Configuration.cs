using DrawNet.Lib.DataContext.Tables;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DrawNet.Lib.DataContext.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {

            if (System.Diagnostics.Debugger.IsAttached == false)
            {
//                System.Diagnostics.Debugger.
//                System.Diagnostics.Debugger.Launch();

            }

            var roleStore = new RoleStore<Tables.ApplicationRole>(context);
            var roleManager = new RoleManager<Tables.ApplicationRole>(roleStore);
            var userStore = new UserStore<Tables.ApplicationUser>(context);
            var userManager = new UserManager<Tables.ApplicationUser>(userStore);

            userManager.UserValidator = new UserValidator<Tables.ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };

            string userName = "BradyLiles";
            string email = "BradyLiles@outlook.com";
            string password = "Passw0rd1";
            string firstName = "Brady";
            string lastName = "Liles";
            string roleName = "Admin";

            var role = new ApplicationRole(roleName);
            if (!roleManager.RoleExistsAsync(roleName).Result)
            {
                var roleResult = roleManager.Create(role);
            }

            var user = userManager.FindByName(userName);

            if (user == null)
            {
                user = new Tables.ApplicationUser
                {
                    UserName = userName,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName
                };

                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            var rolesForUser = userManager.GetRoles(user.Id);

            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}

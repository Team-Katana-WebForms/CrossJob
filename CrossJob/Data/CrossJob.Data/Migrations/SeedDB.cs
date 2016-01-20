namespace CrossJob.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    public static class SeedDB
    {
        public static void Start(CrossJobDbContext context)
        {
            SeedUsers(context);
        }

        private static void SeedUsers(CrossJobDbContext context)
        {
            if (!context.Users.Any())
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                CreateNewUser(userManager, roleManager, "Admin", "admin@test.com", "123456");
                CreateNewUser(userManager, roleManager, "Freelancer", "freelancer@test.com", "123456");
                CreateNewUser(userManager, roleManager, "Employer", "employer@test.com", "123456");
            }
        }

        private static void CreateNewUser(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, string name, string email, string password)
        {
            //Create Role if it does not exist
            if (!roleManager.RoleExists(name))
            {
                var roleresult = roleManager.Create(new IdentityRole(name));
            }

            //Create User with password
            var user = new User();
            user.UserName = email;
            user.Email = email;
            var adminresult = userManager.Create(user, password);

            //Add User to Role
            if (adminresult.Succeeded)
            {
                var result = userManager.AddToRole(user.Id, name);
            }
        }
    }
}

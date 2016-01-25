namespace CrossJob.Data.Migrations
{
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public static class SeedDB
    {
        public static void Start(CrossJobDbContext context)
        {
            SeedUsers(context);
            //SeedCategories(context);
        }

        //private static void SeedCategories(CrossJobDbContext context)
        //{
        //    var data = new[] {
        //        "3D Modeling & CAD",
        //        "Academic Writing & Research",
        //        "Animation",
        //        "Article & Blog Writing",
        //        "Audio Production",
        //        "Copywriting",
        //        "Creative Writing",
        //        "Database Administration",
        //        "Desktop Software Development",
        //        "Editing & Proofreading",
        //        "ERP / CRM Software",
        //        "Game Development",
        //        "Graphic Design",
        //        "Illustration",
        //        "Information Security",
        //        "Logo Design & Branding",
        //        "Market & Customer Research",
        //        "Marketing Strategy",
        //        "Mobile Development",
        //        "Network & System Administration",
        //        "Other - IT & Networking",
        //        "Other - Software Development",
        //        "Photography",
        //        "Presentations",
        //        "Product Management",
        //        "QA & Testing",
        //        "SEM - Search Engine Marketing",
        //        "SEO - Search Engine Optimization",
        //        "SMM - Social Media Marketing",
        //        "Technical Writing",
        //        "Video Production",
        //        "Web & Mobile Design",
        //        "Web Development"
        //        };
        //}

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
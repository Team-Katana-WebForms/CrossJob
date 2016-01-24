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
    using Repositories;

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

//namespace CrossJob.Data.Migrations
//{
//    using System.Collections.Generic;
//    using System.Data.Entity.Migrations;
//    using System.Linq;
//    using Data;
//    using Microsoft.AspNet.Identity;
//    using Microsoft.AspNet.Identity.EntityFramework;
//    using Models;

//    public static class SeedDB
//    {
//        //public static Random Rand = new Random();

//        public static void Start(CrossJobDbContext context)
//        {
//            SeedInitialUsers(context);
//            SeedCategories(context);
//        }

//        private static void SeedCategories(CrossJobDbContext context)
//        {
//            if (!context.Categories.Any())
//            {
//                var categories = new List<Category>();

//                categories.Add(new Category() { Name = "3D Modeling & CAD" });
//                categories.Add(new Category() { Name = "Academic Writing & Research" });
//                categories.Add(new Category() { Name = "Animation" });
//                categories.Add(new Category() { Name = "Article & Blog Writing" });
//                categories.Add(new Category() { Name = "Audio Production" });
//                categories.Add(new Category() { Name = "Copywriting" });
//                categories.Add(new Category() { Name = "Creative Writing" });
//                categories.Add(new Category() { Name = "Database Administration" });
//                categories.Add(new Category() { Name = "Desktop Software Development" });
//                categories.Add(new Category() { Name = "Editing & Proofreading" });
//                categories.Add(new Category() { Name = "ERP / CRM Software" });
//                categories.Add(new Category() { Name = "Game Development" });
//                categories.Add(new Category() { Name = "Graphic Design" });
//                categories.Add(new Category() { Name = "Illustration" });
//                categories.Add(new Category() { Name = "Information Security" });
//                categories.Add(new Category() { Name = "Logo Design & Branding" });
//                categories.Add(new Category() { Name = "Market & Customer Research" });
//                categories.Add(new Category() { Name = "Marketing Strategy" });
//                categories.Add(new Category() { Name = "Mobile Development" });
//                categories.Add(new Category() { Name = "Network & System Administration" });
//                categories.Add(new Category() { Name = "Other - IT & Networking" });
//                categories.Add(new Category() { Name = "Other - Software Development" });
//                categories.Add(new Category() { Name = "Photography" });
//                categories.Add(new Category() { Name = "Presentations" });
//                categories.Add(new Category() { Name = "Product Management" });
//                categories.Add(new Category() { Name = "QA & Testing" });
//                categories.Add(new Category() { Name = "SEM - Search Engine Marketing" });
//                categories.Add(new Category() { Name = "SEO - Search Engine Optimization" });
//                categories.Add(new Category() { Name = "SMM - Social Media Marketing" });
//                categories.Add(new Category() { Name = "Technical Writing" });
//                categories.Add(new Category() { Name = "Video Production" });
//                categories.Add(new Category() { Name = "Web & Mobile Design" });
//                categories.Add(new Category() { Name = "Web Development" });

//                context.Categories.AddOrUpdate(categories.ToArray());
//            }
//        }

//        private static void SeedInitialUsers(CrossJobDbContext context)
//        {
//            if (!context.Users.Any())
//            {
//                var userManager = new UserManager<User>(new UserStore<User>(context));
//                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

//                CreateNewUser(userManager, roleManager, "Admin", "admin@test.com", "123456", 0);

//                for (int i = 0; i < 10; i++)
//                {
//                    CreateNewUser(userManager, roleManager, "Freelancer", "freelancer" + i + 1 + "@test.com", "123456", i + 1);
//                    CreateNewUser(userManager, roleManager, "Employer", "employer" + i + 1 + "@test.com", "123456", i + 1);
//                }
//            }
//        }

//        private static void CreateNewUser(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, string name, string email, string password, int counter)
//        {
//            //Create Role if it does not exist
//            if (!roleManager.RoleExists(name))
//            {
//                var roleresult = roleManager.Create(new IdentityRole(name));
//            }

//            //Create User with password
//            var user = new User();
//            user.UserName = name + counter;
//            user.Email = email;
//            user.Role = name;
//            var newUser = userManager.Create(user, password);

//            //Add User to Role
//            if (newUser.Succeeded)
//            {
//                var result = userManager.AddToRole(user.Id, name);
//            }
//        }
//    }
//}

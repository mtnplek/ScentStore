namespace ScentStore.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ScentStore.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ScentStore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ScentStore.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Products.AddOrUpdate(
                a => a.Name,
                new Models.Product { Name = "Escada: Sorbetto Rosso", Price = 359, InStock = 99, IsFemale = true },
                new Models.Product { Name = "Carolina Herrera: Good Girl", Price = 235, InStock = 99, IsFemale = true },
                new Models.Product { Name = "Giorgio Armani: Si", Price = 805, InStock = 99, IsFemale = true },
                new Models.Product { Name = "Escada: Magnetism", Price = 639, InStock = 99, IsFemale = true },
                new Models.Product { Name = "Hugo Boss: Femme", Price = 390, InStock = 99, IsFemale = true },
                new Models.Product { Name = "Marc Jacobs: Daisy Love", Price = 495, InStock = 99, IsFemale = true },
                new Models.Product { Name = "Yves Saint Laurent: l'homme", Price = 499, InStock = 99, IsFemale = false },
                new Models.Product { Name = "Paco Rabanne: Invictus Aqua", Price = 449, InStock = 99, IsFemale = false },
                new Models.Product { Name = "Hugo Boss: The Scent", Price = 525, InStock = 99, IsFemale = false },
                new Models.Product { Name = "Versace: Eros", Price = 429, InStock = 99, IsFemale = false },
                new Models.Product { Name = "Armani: Code Colonia", Price = 725, InStock = 99, IsFemale = false },
                new Models.Product { Name = "Gucci: Guilty Absolute", Price = 525, InStock = 99, IsFemale = false }
                );

            context.SaveChanges();

            var roleStore = new RoleStore<IdentityRole>(context); //Create role storage in database
            var roleManager = new RoleManager<IdentityRole>(roleStore); //Put the roles in role storage(roleStore)

            roleManager.Create(new IdentityRole("Admin"));
            roleManager.Create(new IdentityRole("User"));

            var userStore = new UserStore<ApplicationUser>(context); //User Storage
            var userManager = new UserManager<ApplicationUser>(userStore); //Put the roles in role storage(roleStore)

            userManager.Create(new ApplicationUser() { Email = "admin@scent.se", UserName = "admin@scent.se" }, "Password!1");
            userManager.Create(new ApplicationUser() { Email = "user@scent.se", UserName = "user@scent.se" }, "Password!1");

            ApplicationUser admin = userManager.FindByEmail("admin@scent.se"); //Test admin
            ApplicationUser user = userManager.FindByEmail("user@scent.se"); //Test user

            userManager.AddToRoles(admin.Id, "Admin");
            userManager.AddToRoles(user.Id, "User");


        }
    }
}

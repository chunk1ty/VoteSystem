namespace VoteSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    using VoteSystem.Common;
    using VoteSystem.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<VoteSystemDbContext>
    {
        public Configuration()
        {
            // TODO set to false in production and create migration by my self
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(VoteSystemDbContext context)
        {
            this.CreateAdministrator(context);
            //this.SimpleData(context);
        }

        private void CreateAdministrator(VoteSystemDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = "123456";

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }
        }

        private void SimpleData(VoteSystemDbContext context)
        {
            if (context.RateSystems.Count() == 0)
            {
               RateSystem ankk = new RateSystem() { Id = 1, RateSystemName = "Anketa", EndDateTime = DateTime.Now, StarDateTime = DateTime.Now };
                RateSystem ankk1 = new RateSystem() { Id = 2, RateSystemName = "Neshto kato anketa", EndDateTime = DateTime.Now, StarDateTime = DateTime.Now };
                RateSystem ank2 = new RateSystem() { Id = 3, RateSystemName = "loren", EndDateTime = DateTime.Now, StarDateTime = DateTime.Now };

                context.SaveChanges();
                context.RateSystems.AddOrUpdate(
                );

                for (int i = 0; i < 20; i++)
                {
                    Random rd = new Random();
                    Question q = new Question() {Id=i+ 1, QuestionName = "Question" + i, RateSystemId = rd.Next(1, 4) };
                    context.Questions.AddOrUpdate(q);
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }
    }
}

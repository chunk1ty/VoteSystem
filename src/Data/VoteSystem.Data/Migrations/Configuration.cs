using System;
using System.Data.Entity.Migrations;
using System.Linq;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VoteSystem.Authentication.Models;
using VoteSystem.Common.Constants;
using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Migrations
{
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
            this.CreateUsers(context, 20);

            // this.SimpleData(context);
        }

        private void CreateAdministrator(VoteSystemDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = "123456";

            // TODO move migration in Authentication project
            //if (!context.Roles.Any())
            //{
            //    // Create admin role
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);
            //    var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
            //    roleManager.Create(role);

            //    // Create admin user
            //    var userStore = new UserStore<AspNetUser>(context);
            //    var userManager = new UserManager<AspNetUser>(userStore);
            //    var user = new AspNetUser
            //    {
            //        UserName = AdministratorUserName,
            //        Email = AdministratorUserName,
            //        FN = 10001,
            //        FirstName = "Admin",
            //        LastName = "Admin",
            //        EmailConfirmed = true
            //    };
            //    userManager.Create(user, AdministratorPassword);

            //    // Assign user to admin role
            //    userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            //}
        }

        private void CreateUsers(VoteSystemDbContext context, int numberOfUsers)
        {
            const string UserPassword = "123456";

            for (int i = 0; i < numberOfUsers; i++)
            {
                var userStore = new UserStore<AspNetUser>(context);
                var userManager = new UserManager<AspNetUser>(userStore);
                var user = new AspNetUser
                {
                    UserName = "user" + i + "@abv.bg",
                    Email = "user" + i + "@abv.bg",
                    FN = 1000 + i,
                    FirstName = "FirstUserName" + i,
                    LastName = "LastUserName" + i,
                    EmailConfirmed = true
                };

                userManager.Create(user, UserPassword);
            }
        }

        private void SimpleData(VoteSystemDbContext context)
        {
            if (context.Surveys.Count() == 0)
            {
                Survey ankk = new Survey() { Id = 1, Name = "Anketa", EndDateTime = DateTime.Now, StarDateTime = DateTime.Now };
                Survey ankk1 = new Survey() { Id = 2, Name = "Neshto kato anketa", EndDateTime = DateTime.Now, StarDateTime = DateTime.Now };
                Survey ank2 = new Survey() { Id = 3, Name = "loren", EndDateTime = DateTime.Now, StarDateTime = DateTime.Now };

                context.SaveChanges();
                context.Surveys.AddOrUpdate(ankk);

                for (int i = 0; i < 20; i++)
                {
                    Random rd = new Random();
                    Question q = new Question() { Id = i + 1, QuestionName = "Question" + i, RateSystemId = rd.Next(1, 4) };
                    context.Questions.AddOrUpdate(q);
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }
    }
}

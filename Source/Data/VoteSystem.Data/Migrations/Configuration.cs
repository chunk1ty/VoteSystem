namespace VoteSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using VoteSystem.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<VoteSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(VoteSystemDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (context.RateSystems.Count() == 0)
            {
                context.RateSystems.AddOrUpdate(
                new RateSystem() { Name = "Anketa", EndDateTime = DateTime.Now, StarDateTime = DateTime.Now },
                new RateSystem() { Name = "Neshto kato anketa", EndDateTime = DateTime.Now, StarDateTime = DateTime.Now },
                new RateSystem() { Name = "loren", EndDateTime = DateTime.Now, StarDateTime = DateTime.Now });

                for (int i = 0; i < 20; i++)
                {
                    Random rd = new Random();
                    context.Questions.AddOrUpdate(new Question() { Name = "Question" + i, Type = "Type" + i, RateSystemId = rd.Next(1, 4) });
                }

                context.SaveChanges();
            }
        }
    }
}

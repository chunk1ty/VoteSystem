namespace VoteSystem.Web.App_Start
{
    using System.Data.Entity;

    using VoteSystem.Data;
    using VoteSystem.Data.Migrations;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VoteSystemDbContext, Configuration>());
        }
    }
}
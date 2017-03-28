namespace VoteSystem.Web
{
    using System.Data.Entity;

    using VoteSystem.Data;
    using VoteSystem.Data.Migrations;

    public class DbConfig
    {
        public static void RegisterDb()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VoteSystemDbContext, Configuration>());
        }
    }
}
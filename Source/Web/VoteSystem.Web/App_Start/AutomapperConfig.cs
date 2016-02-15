namespace VoteSystem.Web
{
    using System.Reflection;

    using VoteSystem.Web.Infrastructure.Mapping;

    public class AutomapperConfig
    {
        public static void RegisterMap()
        { 
            var authoMapper = new AutoMapperConfig();
            authoMapper.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
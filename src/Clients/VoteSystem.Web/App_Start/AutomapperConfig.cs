using System.Reflection;
using VoteSystem.Web.Infrastructure.Mapping;

namespace VoteSystem.Clients.MVC
{
    public class AutomapperConfig
    {
        public static void RegisterMap()
        { 
            var authoMapper = new AutoMapperConfig();
            authoMapper.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
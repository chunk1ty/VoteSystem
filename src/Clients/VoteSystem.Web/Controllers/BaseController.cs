using System.Web.Mvc;
using AutoMapper;
using Ninject;
using VoteSystem.Services.Web.Contracts;
using VoteSystem.Web.Infrastructure.Mapping;

namespace VoteSystem.Clients.MVC.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        [Inject]
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}
using NahhasWeb.API.Controllers.Base;
using NahhasWeb.Shared.Entities;
using NahhasWeb.Shared.UnitOfWorks.Interfaces;

namespace NahhasWeb.API.Controllers
{
    public class VideosController : CrudController<Video>
    {
        public VideosController(IUnitOfWork<Video> uow) : base(uow) { }
    }
}
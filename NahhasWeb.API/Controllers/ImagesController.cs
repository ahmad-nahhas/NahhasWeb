using NahhasWeb.API.Controllers.Base;
using NahhasWeb.Shared.Entities;
using NahhasWeb.Shared.UnitOfWorks.Interfaces;

namespace NahhasWeb.API.Controllers
{
    public class ImagesController : CrudController<Image>
    {
        public ImagesController(IUnitOfWork<Image> uow) : base(uow) { }
    }
}
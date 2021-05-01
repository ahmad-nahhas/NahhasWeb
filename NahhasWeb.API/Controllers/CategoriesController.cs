using NahhasWeb.API.Controllers.Base;
using NahhasWeb.Shared.Entities;
using NahhasWeb.Shared.UnitOfWorks.Interfaces;

namespace NahhasWeb.API.Controllers
{
    public class CategoriesController : CrudController<Category>
    {
        public CategoriesController(IUnitOfWork<Category> uow) : base(uow) { }
    }
}
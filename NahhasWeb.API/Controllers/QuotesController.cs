using NahhasWeb.API.Controllers.Base;
using NahhasWeb.Shared.Entities;
using NahhasWeb.Shared.UnitOfWorks.Interfaces;

namespace NahhasWeb.API.Controllers
{
    public class QuotesController : CrudController<Quote>
    {
        public QuotesController(IUnitOfWork<Quote> uow) : base(uow) { }
    }
}
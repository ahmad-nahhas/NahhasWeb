using System.Linq;

namespace NahhasWeb.Shared.Filters.Interfaces
{
    public interface IFilter<T> where T : class
    {
        IQueryable<T> Build(IQueryable<T> initialSet, bool applyPaging = true);
    }
}
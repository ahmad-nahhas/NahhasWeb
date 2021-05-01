using System.Linq;

namespace NahhasWeb.Shared.Filters.Base
{
    public abstract class PagingFilter<T> where T : class
    {
        private const int maxPageSize = 8;
        private int _pageSize = maxPageSize;

        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > maxPageSize ? maxPageSize : value;
        }

        public IQueryable<T> ConfigurePaging(IQueryable<T> initialSet) =>
            initialSet.Skip((PageNumber - 1) * PageSize).Take(PageSize);
    }
}
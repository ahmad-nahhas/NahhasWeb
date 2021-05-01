using NahhasWeb.Shared.Repositories.Interfaces;
using System.Threading.Tasks;

namespace NahhasWeb.Shared.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IRepository<T> Database { get; }
        Task<int> Save();
    }
}
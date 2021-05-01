using NahhasWeb.Shared.Entities.Base;
using NahhasWeb.Shared.Repositories.Base;
using NahhasWeb.Shared.Repositories.Interfaces;
using NahhasWeb.Shared.UnitOfWorks.Interfaces;
using System.Threading.Tasks;

namespace NahhasWeb.Shared.UnitOfWorks.Base
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : EntityBase
    {
        private readonly NahhasWebDbContext _context;
        private IRepository<T> _repository;

        public UnitOfWork(NahhasWebDbContext context)
        {
            _context = context;
        }

        public IRepository<T> Database => _repository ??= new Repository<T>(_context);
        public async Task<int> Save() => await _context.SaveChangesAsync();
    }
}
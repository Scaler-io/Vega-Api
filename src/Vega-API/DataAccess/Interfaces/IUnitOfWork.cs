using System;
using System.Threading.Tasks;

namespace Vega_API.DataAccess.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> Complete();
    }
}

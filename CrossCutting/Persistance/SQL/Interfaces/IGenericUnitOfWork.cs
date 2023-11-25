using System.Threading.Tasks;
using CrossCutting.Persistance.SQL.Entities;

namespace CrossCutting.Persistance.SQL.Interfaces
{
    public interface IGenericUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        IGenericRepository<TEntity> Repository { get; }

        void Dispose();
        Task Save();
    }
}
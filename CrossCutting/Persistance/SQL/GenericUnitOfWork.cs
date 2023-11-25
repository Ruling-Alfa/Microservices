using CrossCutting.Persistance.SQL.Entities;
using CrossCutting.Persistance.SQL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;


namespace CrossCutting.Persistance.SQL
{
    public class GenericUnitOfWork<TEntity> : IDisposable, IGenericUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        private DbContext _dbContext;
        private IGenericRepository<TEntity> _repo;
        public GenericUnitOfWork(DbContext dbContext, IGenericRepository<TEntity> repo)
        {
            _dbContext = dbContext;
            _repo = repo;
        }
        public IGenericRepository<TEntity> Repository
        {
            get
            {
                return _repo;
            }
        }

        public Task Save()
        {
            return _dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

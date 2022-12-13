using EnergyControl.Domain.Entities;
using EnergyControl.Infrastructure;
using System;
using System.Threading.Tasks;

namespace EnergyControl.Application.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EnergyControlContext _context;

        public UnitOfWork(EnergyControlContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            return new MSSQLRepository<T>(_context);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        #region IDisposable
        private bool disposed = false;

        protected void DisposeContext()
        {
            if (disposed) return;

            disposed = true;
            _context.Dispose();
        }

        public void Dispose()
        {
            DisposeContext();
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork() => DisposeContext();
        #endregion
    }
}

using System.Threading.Tasks;
using IOTLabWebApi.Core;

namespace IOTLabWebApi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IotLabDbContext DbContext { get; }
        public UnitOfWork(IotLabDbContext dbContext)
        {
            this.DbContext = dbContext;

        }

    public async Task CompleteAsync()
    {
      await DbContext.SaveChangesAsync();
    }

    }
}
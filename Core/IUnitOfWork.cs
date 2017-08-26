using System.Threading.Tasks;

namespace IOTLabWebApi.Core
{
    public interface IUnitOfWork
    {     
    Task CompleteAsync();
    }
}
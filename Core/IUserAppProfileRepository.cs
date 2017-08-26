using System.Threading.Tasks;
using IOTLabWebApi.Core.Models;

namespace IOTLabWebApi.Core
{
    public interface IUserAppProfileRepository
    {
        Task<UserAppProfile> GetUserAppProfile(int id);
        UserAppProfile GetUserAppProfileByEmail(string email);
        bool UserHasProfile(string email);
         bool Add(UserAppProfile userProfile);
         void Remove(UserAppProfile userProfile);
    }
}
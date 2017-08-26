using System.Linq;
using System.Threading.Tasks;
using IOTLabWebApi.Core;
using IOTLabWebApi.Core.Models;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace IOTLabWebApi.Persistence
{
    public class UserAppProfileRepository : IUserAppProfileRepository
    {
        private readonly IotLabDbContext context;
        public UserAppProfileRepository(IotLabDbContext context)
        {
            this.context = context;

        }

        public bool Add(UserAppProfile userProfile)
        {   
            if(context.UserAppProfiles.Any(u=>u.Email == userProfile.Email))
                return false;      
            else{
                context.UserAppProfiles.Add(userProfile);
                return true;
            } 
        }

        public async Task<UserAppProfile> GetUserAppProfile(int id)
        {
            return await context.UserAppProfiles.FindAsync(id);
        }

        public UserAppProfile GetUserAppProfileByEmail(string email)
        {
            var profile = context.UserAppProfiles.FirstOrDefault(u=>u.Email == email);
            return profile;
        }

        public void Remove(UserAppProfile userProfile)
        {
            throw new System.NotImplementedException();
        }

        public bool UserHasProfile(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}
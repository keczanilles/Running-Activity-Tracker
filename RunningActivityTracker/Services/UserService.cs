using System.Collections.Generic;
using System.Threading.Tasks;
using RunningActivityTracker.Entities;

namespace RunningActivityTracker.Services
{
    public class UserService :  IUserService
    {
        public UserEntity FindCurrentUser()
        {
            throw new System.NotImplementedException();
        }

        public void CreateUser(UserEntity user)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserEntity> AuthenticateAsync(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}

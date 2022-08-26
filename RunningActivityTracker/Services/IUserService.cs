using System.Collections.Generic;
using System.Threading.Tasks;
using RunningActivityTracker.Entities;

namespace RunningActivityTracker.Services
{
    public interface IUserService
    {
        UserEntity FindCurrentUser(string userName);
        void CreateUser(UserEntity user);
        Task<UserEntity> AuthenticateAsync(string userName, string password);
        IEnumerable<UserEntity> GetAll();
    }
}

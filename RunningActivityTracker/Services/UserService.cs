using System.Collections.Generic;
using System.Threading.Tasks;
using RunningActivityTracker.Entities;
using RunningActivityTracker.Repositories;

namespace RunningActivityTracker.Services
{
    public class UserService :  IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public UserEntity FindCurrentUser(string userName)
        {
            return _repository.FindUserByName(userName);
        }

        public void CreateUser(UserEntity user)
        {
            _repository.CreateUser(user);
        }

        public Task<UserEntity> AuthenticateAsync(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
